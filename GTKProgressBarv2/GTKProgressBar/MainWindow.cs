using System;
using System.IO;
using Gtk;
using System.Text;


public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnRunClicked (object sender, EventArgs e)
	{
		try {
			int val1 = int.Parse(TxtLoopVal1.Buffer.Text);
			int val2 = int.Parse(TxtLoopVal2.Buffer.Text);

				PrgBar1.Adjustment.Lower = 0;
				PrgBar1.PulseStep = 1;
				PrgBar1.Adjustment.Upper = val1;

				PrgBar2.Adjustment.Lower = 0;
				PrgBar2.PulseStep = 1;
				PrgBar2.Adjustment.Upper = val2;

				for (int i = 0; i <= val1; i++) {
					PrgBar1.Pulse();
					PrgBar1.Fraction = i/val1;
					PrgBar1.Text = i.ToString(); 
					PrgBar1.Adjustment.Value = i;
					Main.IterationDo(false);
					for (int j = 0; j <= val2; j++) {
						PrgBar2.Pulse();
						PrgBar2.Fraction = j/val2;
						PrgBar2.Text = j.ToString();
						PrgBar2.Adjustment.Value = j;
						Main.IterationDo(false);
					}
				}

		} catch (Exception ex) {
			throw new ApplicationException (ex.Message); 
		}
	}
	protected void OnRunApplicationActionActivated (object sender, EventArgs e)
	{
		OnBtnRunClicked (sender, e);
	}
		
	protected void OnExitActionActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}
}
