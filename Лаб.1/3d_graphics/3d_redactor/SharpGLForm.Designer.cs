namespace SharpGLWinformsApplication2
{
    partial class SharpGLForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.setRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.setHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
            this.drawToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pryzmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setXYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox6 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox7 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox8 = new System.Windows.Forms.ToolStripTextBox();
            this.setLenghtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox9 = new System.Windows.Forms.ToolStripTextBox();
            this.setHeightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox10 = new System.Windows.Forms.ToolStripTextBox();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectingFiguresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setChoosenFiguresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveFiguresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byXaxeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byYaxeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byZaxeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnFiguresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byXaxeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byYaxeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byZaxeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentOfFigufeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteFiguresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.Location = new System.Drawing.Point(0, 28);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(956, 447);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.Click += new System.EventHandler(this.openGLControl_Click);
            this.openGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGLForm_KeyDown);
            this.openGLControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SharpGLForm_KeyDown);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseClick);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.selectingFiguresToolStripMenuItem,
            this.moveFiguresToolStripMenuItem,
            this.turnFiguresToolStripMenuItem,
            this.toolStripMenuItem3,
            this.changeColorToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.deleteFiguresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGLForm_KeyDown);
            this.menuStrip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseClick);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseMove);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cylinderToolStripMenuItem,
            this.pryzmaToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 24);
            this.toolStripMenuItem1.Text = "Add figure";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem1.MouseHover += new System.EventHandler(this.toolStripMenuItem1_MouseHover);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.setRadiusToolStripMenuItem,
            this.setHeightToolStripMenuItem,
            this.drawToolStripMenuItem1});
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            this.cylinderToolStripMenuItem.Click += new System.EventHandler(this.cylinderToolStripMenuItem_Click);
            this.cylinderToolStripMenuItem.MouseHover += new System.EventHandler(this.cylinderToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox2,
            this.toolStripTextBox3});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItem2.Text = "set X, Y, Z:";
            this.toolStripMenuItem2.MouseHover += new System.EventHandler(this.toolStripMenuItem2_MouseHover);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 27);
            // 
            // setRadiusToolStripMenuItem
            // 
            this.setRadiusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox4});
            this.setRadiusToolStripMenuItem.Name = "setRadiusToolStripMenuItem";
            this.setRadiusToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.setRadiusToolStripMenuItem.Text = "set Radius:";
            this.setRadiusToolStripMenuItem.MouseHover += new System.EventHandler(this.setRadiusToolStripMenuItem_MouseHover);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 27);
            // 
            // setHeightToolStripMenuItem
            // 
            this.setHeightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox5});
            this.setHeightToolStripMenuItem.Name = "setHeightToolStripMenuItem";
            this.setHeightToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.setHeightToolStripMenuItem.Text = "set Height";
            this.setHeightToolStripMenuItem.MouseHover += new System.EventHandler(this.setHeightToolStripMenuItem_MouseHover);
            // 
            // toolStripTextBox5
            // 
            this.toolStripTextBox5.Name = "toolStripTextBox5";
            this.toolStripTextBox5.Size = new System.Drawing.Size(100, 27);
            // 
            // drawToolStripMenuItem1
            // 
            this.drawToolStripMenuItem1.Name = "drawToolStripMenuItem1";
            this.drawToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.drawToolStripMenuItem1.Text = "Draw";
            this.drawToolStripMenuItem1.Click += new System.EventHandler(this.drawToolStripMenuItem1_Click);
            this.drawToolStripMenuItem1.MouseHover += new System.EventHandler(this.drawToolStripMenuItem1_MouseHover);
            // 
            // pryzmaToolStripMenuItem
            // 
            this.pryzmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setXYZToolStripMenuItem,
            this.setLenghtToolStripMenuItem,
            this.setHeightToolStripMenuItem1,
            this.drawToolStripMenuItem});
            this.pryzmaToolStripMenuItem.Name = "pryzmaToolStripMenuItem";
            this.pryzmaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.pryzmaToolStripMenuItem.Text = "Pryzma";
            this.pryzmaToolStripMenuItem.MouseHover += new System.EventHandler(this.pryzmaToolStripMenuItem_MouseHover);
            // 
            // setXYZToolStripMenuItem
            // 
            this.setXYZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox6,
            this.toolStripTextBox7,
            this.toolStripTextBox8});
            this.setXYZToolStripMenuItem.Name = "setXYZToolStripMenuItem";
            this.setXYZToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.setXYZToolStripMenuItem.Text = "set X, Y, Z:";
            this.setXYZToolStripMenuItem.MouseHover += new System.EventHandler(this.setXYZToolStripMenuItem_MouseHover);
            // 
            // toolStripTextBox6
            // 
            this.toolStripTextBox6.Name = "toolStripTextBox6";
            this.toolStripTextBox6.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripTextBox7
            // 
            this.toolStripTextBox7.Name = "toolStripTextBox7";
            this.toolStripTextBox7.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripTextBox8
            // 
            this.toolStripTextBox8.Name = "toolStripTextBox8";
            this.toolStripTextBox8.Size = new System.Drawing.Size(100, 27);
            // 
            // setLenghtToolStripMenuItem
            // 
            this.setLenghtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox9});
            this.setLenghtToolStripMenuItem.Name = "setLenghtToolStripMenuItem";
            this.setLenghtToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.setLenghtToolStripMenuItem.Text = "set Lenght:";
            this.setLenghtToolStripMenuItem.MouseHover += new System.EventHandler(this.setLenghtToolStripMenuItem_MouseHover);
            // 
            // toolStripTextBox9
            // 
            this.toolStripTextBox9.Name = "toolStripTextBox9";
            this.toolStripTextBox9.Size = new System.Drawing.Size(100, 27);
            // 
            // setHeightToolStripMenuItem1
            // 
            this.setHeightToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox10});
            this.setHeightToolStripMenuItem1.Name = "setHeightToolStripMenuItem1";
            this.setHeightToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.setHeightToolStripMenuItem1.Text = "set Height";
            this.setHeightToolStripMenuItem1.MouseHover += new System.EventHandler(this.setHeightToolStripMenuItem1_MouseHover);
            // 
            // toolStripTextBox10
            // 
            this.toolStripTextBox10.Name = "toolStripTextBox10";
            this.toolStripTextBox10.Size = new System.Drawing.Size(100, 27);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.drawToolStripMenuItem.Text = "Draw";
            this.drawToolStripMenuItem.Click += new System.EventHandler(this.drawToolStripMenuItem_Click);
            this.drawToolStripMenuItem.MouseHover += new System.EventHandler(this.drawToolStripMenuItem_MouseHover);
            // 
            // selectingFiguresToolStripMenuItem
            // 
            this.selectingFiguresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.deleteSelectingToolStripMenuItem});
            this.selectingFiguresToolStripMenuItem.Name = "selectingFiguresToolStripMenuItem";
            this.selectingFiguresToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.selectingFiguresToolStripMenuItem.Text = "Selecting figure(s)";
            this.selectingFiguresToolStripMenuItem.Click += new System.EventHandler(this.selectingFiguresToolStripMenuItem_Click);
            this.selectingFiguresToolStripMenuItem.MouseHover += new System.EventHandler(this.selectingFiguresToolStripMenuItem_MouseHover);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setChoosenFiguresToolStripMenuItem,
            this.chooseToolStripMenuItem});
            this.toolStripComboBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(191, 26);
            this.toolStripComboBox1.Text = "Select";
            this.toolStripComboBox1.MouseHover += new System.EventHandler(this.toolStripComboBox1_MouseHover);
            // 
            // setChoosenFiguresToolStripMenuItem
            // 
            this.setChoosenFiguresToolStripMenuItem.Enabled = false;
            this.setChoosenFiguresToolStripMenuItem.Name = "setChoosenFiguresToolStripMenuItem";
            this.setChoosenFiguresToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.setChoosenFiguresToolStripMenuItem.Text = "set choosen figures";
            this.setChoosenFiguresToolStripMenuItem.Click += new System.EventHandler(this.setChoosenFiguresToolStripMenuItem_Click);
            // 
            // chooseToolStripMenuItem
            // 
            this.chooseToolStripMenuItem.Name = "chooseToolStripMenuItem";
            this.chooseToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.chooseToolStripMenuItem.Text = "choose";
            this.chooseToolStripMenuItem.Click += new System.EventHandler(this.chooseToolStripMenuItem_Click);
            // 
            // deleteSelectingToolStripMenuItem
            // 
            this.deleteSelectingToolStripMenuItem.Enabled = false;
            this.deleteSelectingToolStripMenuItem.Name = "deleteSelectingToolStripMenuItem";
            this.deleteSelectingToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.deleteSelectingToolStripMenuItem.Text = "Delete selecting";
            this.deleteSelectingToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectingToolStripMenuItem_Click);
            this.deleteSelectingToolStripMenuItem.MouseHover += new System.EventHandler(this.deleteSelectingToolStripMenuItem_MouseHover);
            // 
            // moveFiguresToolStripMenuItem
            // 
            this.moveFiguresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byXaxeToolStripMenuItem,
            this.byYaxeToolStripMenuItem,
            this.byZaxeToolStripMenuItem});
            this.moveFiguresToolStripMenuItem.Name = "moveFiguresToolStripMenuItem";
            this.moveFiguresToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.moveFiguresToolStripMenuItem.Text = "Move figure(s)";
            this.moveFiguresToolStripMenuItem.Click += new System.EventHandler(this.moveFiguresToolStripMenuItem_Click);
            this.moveFiguresToolStripMenuItem.MouseHover += new System.EventHandler(this.moveFiguresToolStripMenuItem_MouseHover);
            // 
            // byXaxeToolStripMenuItem
            // 
            this.byXaxeToolStripMenuItem.Name = "byXaxeToolStripMenuItem";
            this.byXaxeToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.byXaxeToolStripMenuItem.Text = "by X-axe";
            this.byXaxeToolStripMenuItem.Click += new System.EventHandler(this.byXaxeToolStripMenuItem_Click);
            // 
            // byYaxeToolStripMenuItem
            // 
            this.byYaxeToolStripMenuItem.Name = "byYaxeToolStripMenuItem";
            this.byYaxeToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.byYaxeToolStripMenuItem.Text = "by Y-axe";
            this.byYaxeToolStripMenuItem.Click += new System.EventHandler(this.byYaxeToolStripMenuItem_Click);
            // 
            // byZaxeToolStripMenuItem
            // 
            this.byZaxeToolStripMenuItem.Name = "byZaxeToolStripMenuItem";
            this.byZaxeToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.byZaxeToolStripMenuItem.Text = "by Z-axe";
            this.byZaxeToolStripMenuItem.Click += new System.EventHandler(this.byZaxeToolStripMenuItem_Click);
            // 
            // turnFiguresToolStripMenuItem
            // 
            this.turnFiguresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byXaxeToolStripMenuItem1,
            this.byYaxeToolStripMenuItem1,
            this.byZaxeToolStripMenuItem1});
            this.turnFiguresToolStripMenuItem.Name = "turnFiguresToolStripMenuItem";
            this.turnFiguresToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.turnFiguresToolStripMenuItem.Text = "Turn figure(s)";
            this.turnFiguresToolStripMenuItem.Click += new System.EventHandler(this.turnFiguresToolStripMenuItem_Click);
            this.turnFiguresToolStripMenuItem.MouseHover += new System.EventHandler(this.turnFiguresToolStripMenuItem_MouseHover);
            // 
            // byXaxeToolStripMenuItem1
            // 
            this.byXaxeToolStripMenuItem1.Name = "byXaxeToolStripMenuItem1";
            this.byXaxeToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.byXaxeToolStripMenuItem1.Text = "by X-axe";
            this.byXaxeToolStripMenuItem1.Click += new System.EventHandler(this.byXaxeToolStripMenuItem1_Click);
            // 
            // byYaxeToolStripMenuItem1
            // 
            this.byYaxeToolStripMenuItem1.Name = "byYaxeToolStripMenuItem1";
            this.byYaxeToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.byYaxeToolStripMenuItem1.Text = "by Y-axe";
            this.byYaxeToolStripMenuItem1.Click += new System.EventHandler(this.byYaxeToolStripMenuItem1_Click);
            // 
            // byZaxeToolStripMenuItem1
            // 
            this.byZaxeToolStripMenuItem1.Name = "byZaxeToolStripMenuItem1";
            this.byZaxeToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.byZaxeToolStripMenuItem1.Text = "by Z-axe";
            this.byZaxeToolStripMenuItem1.Click += new System.EventHandler(this.byZaxeToolStripMenuItem1_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(122, 24);
            this.toolStripMenuItem3.Text = "Resize figure(s)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figureToolStripMenuItem,
            this.componentOfFigufeToolStripMenuItem});
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.changeColorToolStripMenuItem.Text = "Change color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            this.changeColorToolStripMenuItem.MouseHover += new System.EventHandler(this.changeColorToolStripMenuItem_MouseHover);
            // 
            // figureToolStripMenuItem
            // 
            this.figureToolStripMenuItem.Name = "figureToolStripMenuItem";
            this.figureToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.figureToolStripMenuItem.Text = "Figure(s)";
            this.figureToolStripMenuItem.Click += new System.EventHandler(this.figureToolStripMenuItem_Click);
            // 
            // componentOfFigufeToolStripMenuItem
            // 
            this.componentOfFigufeToolStripMenuItem.Name = "componentOfFigufeToolStripMenuItem";
            this.componentOfFigufeToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.componentOfFigufeToolStripMenuItem.Text = "Component of figufe";
            this.componentOfFigufeToolStripMenuItem.Click += new System.EventHandler(this.componentOfFigufeToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveInDBToolStripMenuItem,
            this.loadFromDBToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // saveInDBToolStripMenuItem
            // 
            this.saveInDBToolStripMenuItem.Name = "saveInDBToolStripMenuItem";
            this.saveInDBToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveInDBToolStripMenuItem.Text = "Save in DB";
            this.saveInDBToolStripMenuItem.Click += new System.EventHandler(this.saveInDBToolStripMenuItem_Click);
            this.saveInDBToolStripMenuItem.MouseHover += new System.EventHandler(this.saveInDBToolStripMenuItem_MouseHover);
            // 
            // loadFromDBToolStripMenuItem
            // 
            this.loadFromDBToolStripMenuItem.Name = "loadFromDBToolStripMenuItem";
            this.loadFromDBToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadFromDBToolStripMenuItem.Text = "Load from DB";
            this.loadFromDBToolStripMenuItem.Click += new System.EventHandler(this.loadFromDBToolStripMenuItem_Click);
            this.loadFromDBToolStripMenuItem.MouseHover += new System.EventHandler(this.loadFromDBToolStripMenuItem_MouseHover);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.White;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(838, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(118, 447);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // deleteFiguresToolStripMenuItem
            // 
            this.deleteFiguresToolStripMenuItem.Name = "deleteFiguresToolStripMenuItem";
            this.deleteFiguresToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.deleteFiguresToolStripMenuItem.Text = "Delete figure(s)";
            this.deleteFiguresToolStripMenuItem.Click += new System.EventHandler(this.deleteFiguresToolStripMenuItem_Click);
            this.deleteFiguresToolStripMenuItem.MouseHover += new System.EventHandler(this.deleteFiguresToolStripMenuItem_MouseHover);
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(956, 475);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SharpGLForm";
            this.Text = "SharpGL Form";
            this.Load += new System.EventHandler(this.SharpGLForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGLForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SharpGLForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SharpGLForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pryzmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripMenuItem setRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripMenuItem setHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox5;
        private System.Windows.Forms.ToolStripMenuItem setXYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox7;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox8;
        private System.Windows.Forms.ToolStripMenuItem setLenghtToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox9;
        private System.Windows.Forms.ToolStripMenuItem setHeightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox10;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectingFiguresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem setChoosenFiguresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveFiguresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byXaxeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byYaxeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byZaxeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnFiguresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byXaxeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem byYaxeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem byZaxeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figureToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem componentOfFigufeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveInDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromDBToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem deleteFiguresToolStripMenuItem;
    }
}

