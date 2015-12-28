
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	private global::Gtk.Label label1;
	private global::Gtk.Entry guess;
	private global::Gtk.Button button_try;
	private global::Gtk.Label label2;
	private global::Gtk.Entry attempts;
	private global::Gtk.Entry attemptslist;
	private global::Gtk.Button button_newgame;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 7;
		// Container child vbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Введите число:");
		this.vbox1.Add (this.label1);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label1]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.guess = new global::Gtk.Entry ();
		this.guess.CanFocus = true;
		this.guess.Name = "guess";
		this.guess.IsEditable = true;
		this.guess.InvisibleChar = '•';
		this.vbox1.Add (this.guess);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.guess]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.button_try = new global::Gtk.Button ();
		this.button_try.CanFocus = true;
		this.button_try.Name = "button_try";
		this.button_try.UseUnderline = true;
		this.button_try.Label = global::Mono.Unix.Catalog.GetString ("Сделать попытку");
		this.vbox1.Add (this.button_try);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.button_try]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Попыток:");
		this.vbox1.Add (this.label2);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label2]));
		w4.Position = 3;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.attempts = new global::Gtk.Entry ();
		this.attempts.CanFocus = true;
		this.attempts.Name = "attempts";
		this.attempts.Text = global::Mono.Unix.Catalog.GetString ("0");
		this.attempts.IsEditable = false;
		this.attempts.InvisibleChar = '•';
		this.vbox1.Add (this.attempts);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.attempts]));
		w5.Position = 4;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.attemptslist = new global::Gtk.Entry ();
		this.attemptslist.CanFocus = true;
		this.attemptslist.Name = "attemptslist";
		this.attemptslist.IsEditable = false;
		this.attemptslist.InvisibleChar = '•';
		this.vbox1.Add (this.attemptslist);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.attemptslist]));
		w6.Position = 5;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.button_newgame = new global::Gtk.Button ();
		this.button_newgame.CanFocus = true;
		this.button_newgame.Name = "button_newgame";
		this.button_newgame.UseUnderline = true;
		this.button_newgame.Label = global::Mono.Unix.Catalog.GetString ("Новая игра");
		this.vbox1.Add (this.button_newgame);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.button_newgame]));
		w7.Position = 6;
		w7.Expand = false;
		w7.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 324;
		this.DefaultHeight = 211;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.DefaultActivated += new global::System.EventHandler (this.OnDefaultActivated);
		this.button_try.Clicked += new global::System.EventHandler (this.OnButtonTryClicked);
		this.button_newgame.Clicked += new global::System.EventHandler (this.OnButtonNewgameClicked);
	}
}
