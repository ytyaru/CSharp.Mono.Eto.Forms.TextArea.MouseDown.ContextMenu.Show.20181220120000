using System;
//using System.Reflection;
//using System.ComponentModel;
using Eto.Forms;
//using Eto.Widget;
using Eto.Drawing;

namespace Hello0
{
    public partial class MainForm : Form
    {

        private RichTextArea textarea1;
        private WebView webView1;
		private FontDialog fontDialog1;
		private ContextMenu textareaContextMenu1;
        public MainForm()
        {
            Title = "Eto.Forms.DynamicLayout.TextArea.MouseEvent + ContextMenu.Show()";
            ClientSize = new Size(800, 600);
            CreateUi();
        }
        private void CreateUi()
        {
            //textarea1 = new RichTextArea() { Width=this.Width/2, Height=this.Height, Text="何かしらの文字列。" };
            textarea1 = new RichTextArea() { Width=1, Height=1, Text="何かしらの文字列。" };
            textarea1.Focus();
            textarea1.KeyDown += Textarea1_KeyDown;
            webView1 = new WebView() { Width=1, Height=1, Url=new Uri("https://www.google.co.jp") } ;
            //webView1 = new WebView() { Width=this.Width/2, Height=this.Height, Url=new Uri("https://www.google.co.jp") } ;
            var splitter= new Eto.Forms.Splitter();
            splitter.Panel1 = textarea1;
            splitter.Panel2 = webView1;
            //splitter.Panel1.Width = this.Width / 2;
            fontDialog1 = new FontDialog();
            fontDialog1.FontChanged += Dialog_FontChanged;
            textareaContextMenu1 = new ContextMenu();
			Command showFontDialog = new Command();
			showFontDialog.MenuText = "フォント";
            showFontDialog.Executed += Command_Executed;
			textareaContextMenu1.Items.Add(showFontDialog);

            // デフォルトMouseDownイベントを消せない……
			//textarea1.MouseDown -= textarea1.MouseDown;
			//textarea1.MouseDown += null;
			//foreach (Delegate d in (textarea1.MouseDown as Eto.Widget.Hander).GetInvocationList()) {
			//EventHandler.RemoveAll();
            //foreach (EventHandler<Eto.Forms.MouseEventArgs> d in (textarea1.MouseDown as Eto.Widget.Hander).GetInvocationList()) {
            //foreach (EventHandler<Eto.Forms.MouseEventArgs> d in (textarea1.MouseDown as EventHandler<Eto.Forms.MouseEventArgs>).GetInvocationList()) {
            //    textarea1.MouseDown -= d;
            //};
            //textarea1.MouseDown as EventHandler
            //EventHandler a = new EventHandler((object sender, EventArgs e)=>{});
            //a.GetInvocationList();
            //Delegate.RemoveAll(textarea1.MouseDown);
            //textarea1.MouseDown.GetInvocationList()
            //textarea1.GetType().GetRuntimeFields()
            //textarea1.GetType().GetRuntimeProperties()
            //foreach (EventInfo info in textarea1.GetType().GetRuntimeEvents()) {
            //}
            textarea1.MouseDown += Textarea1_MouseDown;
            Content = new TableLayout() {
                Padding = 0,
                Spacing = new Size(0, 0),
                Rows = {
                    new TableRow(splitter),
                }
            };
        }
        void Textarea1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Keys.Escape) { fontDialog1.ShowDialog(textarea1); }
        }
        void Dialog_FontChanged(object sender, EventArgs e)
        {
			textarea1.Font = fontDialog1.Font;
        }
        void Command_Executed(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog(textarea1);
        }
        void Textarea1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Buttons == MouseButtons.Alternate) { fontDialog1.ShowDialog(textarea1); }
            if (e.Buttons == MouseButtons.Alternate) { textareaContextMenu1.Show(textarea1); }
        }
        //private void RemoveClickEvent(Button b)
        //{
        //    FieldInfo f1 = typeof(Control).GetField("EventClick", 
        //        BindingFlags.Static | BindingFlags.NonPublic);
        //    object obj = f1.GetValue(b);
        //    PropertyInfo pi = b.GetType().GetProperty("Events",  
        //        BindingFlags.NonPublic | BindingFlags.Instance);
        //    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
        //    list.RemoveHandler(obj, list[obj]);
        //}

    }
}
