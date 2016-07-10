using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WebServiceDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtCSharp;
		private System.Windows.Forms.TextBox txtVB;
		private System.Windows.Forms.Button cmdConvert;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtCSharp = new System.Windows.Forms.TextBox();
			this.txtVB = new System.Windows.Forms.TextBox();
			this.cmdConvert = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtCSharp
			// 
			this.txtCSharp.AcceptsReturn = true;
			this.txtCSharp.AcceptsTab = true;
			this.txtCSharp.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCSharp.Location = new System.Drawing.Point(8, 32);
			this.txtCSharp.Multiline = true;
			this.txtCSharp.Name = "txtCSharp";
			this.txtCSharp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCSharp.Size = new System.Drawing.Size(648, 184);
			this.txtCSharp.TabIndex = 0;
			this.txtCSharp.Text = "";
			this.txtCSharp.WordWrap = false;
			// 
			// txtVB
			// 
			this.txtVB.AcceptsReturn = true;
			this.txtVB.AcceptsTab = true;
			this.txtVB.BackColor = System.Drawing.Color.Black;
			this.txtVB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtVB.ForeColor = System.Drawing.Color.Silver;
			this.txtVB.Location = new System.Drawing.Point(8, 248);
			this.txtVB.Multiline = true;
			this.txtVB.Name = "txtVB";
			this.txtVB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtVB.Size = new System.Drawing.Size(648, 184);
			this.txtVB.TabIndex = 1;
			this.txtVB.Text = "";
			this.txtVB.WordWrap = false;
			// 
			// cmdConvert
			// 
			this.cmdConvert.Location = new System.Drawing.Point(576, 8);
			this.cmdConvert.Name = "cmdConvert";
			this.cmdConvert.TabIndex = 2;
			this.cmdConvert.Text = "Convert";
			this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter C# Code Block:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Generated VB.Net Code:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 445);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.label1,
																		  this.cmdConvert,
																		  this.txtVB,
																		  this.txtCSharp});
			this.Name = "Form1";
			this.Text = "Convert C# To VB using a Web Service";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void cmdConvert_Click(object sender, System.EventArgs e)
		{
			net.kamalpatel.www.ConvertCSharp2VBService o = new net.kamalpatel.www.ConvertCSharp2VBService();
			string lcStr = o.Execute(this.txtCSharp.Text);
			this.txtVB.Text = lcStr.Replace("\n", "\r\n");
		}
	}
}
