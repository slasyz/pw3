using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
	class Student
	{
		public int ID { get; set; }
		public string LastName { get; set; } // Фамилия
		public string FirstName { get; set; } // Имя
		public string SecondName { get; set; } // Отчество
		public int GroupNum { get; set; } // Номер группы
	}

	class Mark
	{
		public int ID { get; set; }
		public string Subject { get; set; }
		public int MarkType { get; set; }
		public int Status { get; set; }
		public int SessionNumber { get; set; }
		public int StudentID { get; set; }
	}

	class Change
	{
		public int ID { get; set; }
		public int OldID { get; set; }
		public int NewID { get; set; }
		public DateTime ChangeDate { get; set; }
		public string Description { get; set; }
	}

	class MainClass
	{
		public static List<Student> studentsList;
		public static List<Mark> marksList;
		public static List<Change> changesList;

		public static List<Student> GetAllStudents ()
		{
			return new List<Student> {
				new Student { ID = 123000, LastName = "Иванов", FirstName = "Иван", SecondName = "Иванович", GroupNum = 123 },
				new Student { ID = 123001, LastName = "Петров", FirstName = "Петр", SecondName = "Петрович", GroupNum = 123 },
				new Student { ID = 123002, LastName = "Красникова", FirstName = "Мария", SecondName = "Сергеевна", GroupNum = 123 },
				new Student { ID = 123003, LastName = "Сергеев", FirstName = "Сергей", SecondName = "Сергеевич", GroupNum = 123 },
				new Student { ID = 123004, LastName = "Кузнецова", FirstName = "Марина", SecondName = "Васильевна", GroupNum = 123 },
				new Student { ID = 123005, LastName = "Петрова", FirstName = "Марина", SecondName = "Васильевна", GroupNum = 123 },
				new Student { ID = 123006, LastName = "Иванова", FirstName = "Марина", SecondName = "Васильевна", GroupNum = 123 },
			};
		}

		public static List<Mark> GetAllMarks ()
		{
			List<Mark> res = new List<Mark> {
				new Mark { ID = 951, Subject = "Алгебра", MarkType = 3, Status = 1, SessionNumber = 12345, StudentID = 123000 },
				new Mark { ID = 952, Subject = "Алгебра", MarkType = 3, Status = 1, SessionNumber = 12345, StudentID = 123001 },
				new Mark { ID = 901, Subject = "Алгебра", MarkType = 5, Status = 2, SessionNumber = 12345, StudentID = 123002 },
				new Mark { ID = 953, Subject = "Алгебра", MarkType = 2, Status = 1, SessionNumber = 12345, StudentID = 123002 },
				new Mark { ID = 954, Subject = "Алгебра", MarkType = 4, Status = 1, SessionNumber = 12345, StudentID = 123003 },
				new Mark { ID = 955, Subject = "Алгебра", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123005 },

				new Mark { ID = 961, Subject = "Матан", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123000 },
				new Mark { ID = 962, Subject = "Матан", MarkType = 4, Status = 1, SessionNumber = 12345, StudentID = 123001 },
				new Mark { ID = 963, Subject = "Матан", MarkType = 2, Status = 1, SessionNumber = 12345, StudentID = 123002 },
				new Mark { ID = 964, Subject = "Матан", MarkType = 4, Status = 1, SessionNumber = 12345, StudentID = 123003 },
				new Mark { ID = 965, Subject = "Матан", MarkType = 2, Status = 1, SessionNumber = 12345, StudentID = 123004 },
				
				new Mark { ID = 971, Subject = "Геометрия", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123000 },
				new Mark { ID = 972, Subject = "Геометрия", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123001 },
				new Mark { ID = 973, Subject = "Геометрия", MarkType = 4, Status = 1, SessionNumber = 12345, StudentID = 123002 },
				new Mark { ID = 974, Subject = "Геометрия", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123003 },
				new Mark { ID = 975, Subject = "Геометрия", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123006 },
				
				new Mark { ID = 981, Subject = "Дополнительные главы дискретного анализа", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123004 },
				new Mark { ID = 981, Subject = "Введение в специальность", MarkType = 5, Status = 1, SessionNumber = 12345, StudentID = 123006 },
			};
			return res;
		}

		public static List<Change> GetAllChanges ()
		{
			return new List<Change> {
				new Change { ID = 10, OldID = 123004, NewID = 123005, ChangeDate = new DateTime(2013, 10, 15), Description = "Смена фамилии." },
				new Change { ID = 11, OldID = 123005, NewID = 123006, ChangeDate = new DateTime(2014, 03, 03), Description = "Смена фамилии." },
			};
		}

		public static int CurrentID(int someID)
		{
			int res = someID;
			foreach (var change in changesList) {
				if (change.OldID == res)
					res = change.NewID;
			}
			return res;
		}

		public static void GetAllMarksOfStudentWithChanges (string lastName, string firstName, string secondName)
		{
			LinkedList<int> studentIDs = new LinkedList<int> (
				(from student in studentsList
				 where (student.LastName == lastName) && (student.FirstName == firstName) && (student.SecondName == secondName)
				 select student.ID).ToList()
			);
			int currentStudentID = studentIDs.First.Value;
			int currentID;
			int i;

			// Двигаемся от текущей позиции влево
			currentID = currentStudentID;
			i = changesList.FindIndex ( change => change.NewID == currentID );
			if (i != -1) {
				for (; i >= 0; i--) {
					if (changesList [i].NewID == currentID) {
						currentID = changesList [i].OldID;
						studentIDs.AddFirst (currentID);
					}
				}
			}

			// Двигаемся от текущей позиции вправо
			currentID = currentStudentID;
			i = changesList.FindIndex( change => change.OldID == currentID );
			if (i != -1) {
				for (; i < changesList.Count; i++) {
					if (changesList [i].OldID == currentID) {
						currentID = changesList [i].NewID;
						studentIDs.AddLast (currentID);
					}
				}
			}

			var sessions =
				from mark in marksList
				join student in studentIDs
					on mark.StudentID equals student
				orderby mark.SessionNumber ascending,
					mark.Subject ascending,
					mark.Status ascending
				group mark by mark.SessionNumber
					into session
				select session;

			foreach (var session in sessions) {
				Console.WriteLine ("Оценки студента {1} {2} {3} за сессию {0}: ", session.Key, lastName, firstName, secondName);
				foreach (var mark in session) {
					Console.WriteLine ("{0}: {1} (studentID == {2})", mark.Subject, mark.MarkType, mark.StudentID);
				}
				Console.WriteLine ();
			}
		}

		public static void GetAllMarksOfStudentWithoutChanges (string lastName, string firstName, string secondName)
		{
			var sessions =
				from mark in marksList
				join student in studentsList
					on mark.StudentID equals student.ID
				where (student.LastName == lastName) && (student.FirstName == firstName) && (student.SecondName == secondName)
				orderby mark.SessionNumber ascending,
					mark.Subject ascending,
					mark.Status ascending
				group mark by mark.SessionNumber
					into session
				select session;

			foreach (var session in sessions) {
				Console.WriteLine ("Оценки студента {1} {2} {3} за сессию {0}: ", session.Key, lastName, firstName, secondName);
				foreach (var mark in session) {
					Console.WriteLine ("{0}: {1} (status == {2})", mark.Subject, mark.MarkType, mark.Status);
				}
				Console.WriteLine ();
			}
		}

		public static bool IsSubjectClosed (int groupNumber, int sessionNumber, string subject)
		{
			var students = 
				from mark in marksList
				join student in studentsList
					on mark.StudentID equals student.ID
				where (mark.SessionNumber == sessionNumber) && (mark.Subject == subject) && (student.GroupNum == groupNumber) && (student.ID == CurrentID(student.ID))
				orderby mark.Status descending
				group mark by mark.StudentID
					into stud
				select stud;

			foreach (var student in students) {
				if (student.Count() == 0)
					return false;
				Mark mark = student.Last ();
				if (mark.MarkType == 2) {
					return false;
				}
			}
			return true;
		}

		public static void IsSessionClosed (int groupNumber, int sessionNumber)
		{
			var subjectsList = 
				(from mark in marksList
				 orderby mark.Subject ascending
				 select mark.Subject).Distinct();

			foreach (var subj in subjectsList)
				if (!IsSubjectClosed (groupNumber, sessionNumber, subj)) {
					Console.WriteLine ("Сессия {0} у группы {1} не закрыта.", sessionNumber, groupNumber, subj);
					return;
				}
			Console.WriteLine ("Сессия {0} у группы {1} закрыта.", sessionNumber, groupNumber);
		}

		public static void Main (string[] args)
		{
			studentsList = GetAllStudents ();
			marksList = GetAllMarks ();
			changesList = GetAllChanges ();

			// Вернуть все оценки Петровой Марины Васильевны (с учётом всех изменений)
			GetAllMarksOfStudentWithChanges ("Петрова", "Марина", "Васильевна");
			// Вернуть все оценки Красниковой Марии Сергеевны (без учёта изменений)
			GetAllMarksOfStudentWithoutChanges ("Красникова", "Мария", "Сергеевна");

			// Сдала ли вся группа 123 предмет "алгебра" в сессию 12345
			// последняя (по статусу) оценка должна быть не двойкой
			bool res = IsSubjectClosed (123, 12345, "Алгебра");
			if (res)
				Console.WriteLine ("Алгебра у группы 123 на сессии 12345 {0}.", res ? "закрыт" : "не закрыт");
			else
				Console.WriteLine ("Алгебра у группы 123 на сессии 12345 не закрыт.");
			Console.WriteLine ();

			// Закрылась ли вся группа 123 в сессию 12345
			IsSessionClosed (123, 12345);
		}
	}
}
