using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	int number;

	protected void NewGame()
	{
		Random rnd = new Random ();
		this.number = rnd.Next (0, 11);
		this.attempts.Text = "0";
		this.attemptslist.Text = "";
	}

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnDefaultActivated (object sender, EventArgs a)
	{
		this.NewGame ();
	}

	protected void OnButtonNewgameClicked (object sender, EventArgs e)
	{
		this.NewGame ();
	}

	protected void OnButtonTryClicked (object sender, EventArgs e)
	{
		int guess_int;
		if (int.TryParse (this.guess.Text, out guess_int))
		if ((guess_int >= 0) && (guess_int <= 10))
		if (guess_int != this.number) {
			string message = string.Format("Неверно! Загаданное число {0} выбранного вами.", guess_int < this.number ? "больше" : "меньше", this.number);
			MessageDialog md = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, message);
			md.Run ();
			md.Destroy();

			int attempts_int = int.Parse (this.attempts.Text);
			attempts_int++;
			this.attemptslist.Text += guess_int.ToString ();
			this.attempts.Text = attempts_int.ToString ();
			return;
		} else {
			string message = string.Format ("Верно! Вы угадали число с {0} попытки", this.attempts.Text);
			MessageDialog md = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, message);
			md.Run ();
			md.Destroy();
			Application.Quit ();
			return;
		}

		MessageDialog md_error = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Введите, пожалуйста, число от 0 до 10");
		md_error.Run();
		md_error.Destroy();
	}
}
