
// This file has been generated by the GUI designer. Do not modify.
namespace CCategoria
{
	public partial class CategoriaWindow
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.Label label1;

		private global::Gtk.HButtonBox hbuttonbox4;

		private global::Gtk.Entry entryNombre;

		private global::Gtk.Button buttonSave;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CCategoria.CategoriaWindow
			this.Name = "CCategoria.CategoriaWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("CategoriaWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CCategoria.CategoriaWindow.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("label1");
			this.vbox4.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbuttonbox4 = new global::Gtk.HButtonBox();
			this.hbuttonbox4.Name = "hbuttonbox4";
			this.hbuttonbox4.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			this.vbox4.Add(this.hbuttonbox4);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbuttonbox4]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.entryNombre = new global::Gtk.Entry();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.vbox4.Add(this.entryNombre);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.entryNombre]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseStock = true;
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = "gtk-save";
			this.vbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.buttonSave]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 146;
			this.Show();
		}
	}
}