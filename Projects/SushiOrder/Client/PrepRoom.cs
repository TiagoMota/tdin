using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

class PrepRoom : Form {

    private IOrders ordersList;
    private EventIntermediate inter;
    private Panel panel1;
    private Label label1;
    private Button button1;
    private DataGridView dataGridView1;
    private Button button2;
    private DataGridViewTextBoxColumn id_orded;
    private DataGridViewTextBoxColumn Name;
    private DataGridViewTextBoxColumn Type;
    private DataGridViewTextBoxColumn Quantity;
    private DataGridViewTextBoxColumn State;
    private DataGridViewTextBoxColumn id_prep;
    private DataGridViewTextBoxColumn Name_Prep;
    private DataGridViewTextBoxColumn type_prep;
    private DataGridViewTextBoxColumn qt_prep;
    private DataGridViewTextBoxColumn state_prep;
    private Label label2;
    private DataGridView dataGridView2;

    PrepRoom()
    {
        Text = "Preparation Room";
        try
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new EventIntermediate();
            inter.AddingOrder += OnAddingOrder;
            inter.PreparingOrder += OnPreparingOrder;
            inter.ReadyOrder += OnReadyOrderPrep;
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            ordersList.AddingOrder += inter.FireAddingOrder;
            ordersList.PreparingOrder += inter.FirePreparingOrder;
            ordersList.ReadyOrder += inter.FireReadyOrder;

            InitializeComponent();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Close();
        }
      }

    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[PrepRoom]: InitilizeLifetimeService");
        return null;
    }

    public void OnAddingOrder()
    {
        refreshOrdersList(dataGridView1, ordersList.GetOrdedOrders());
    }

    public void OnPreparingOrder()
    {
        refreshOrdersList(dataGridView1, ordersList.GetOrdedOrders());
        refreshOrdersList(dataGridView2, ordersList.GetPreparingOrders());
    }

    public void OnReadyOrderPrep()
    {
        refreshOrdersList(dataGridView2, ordersList.GetPreparingOrders());
    }


  static void Main(string[] args) {
      Application.Run(new PrepRoom());
     
  }

  private void InitializeComponent()
  {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_orded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_prep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Prep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_prep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qt_prep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_prep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Orders waiting to be Prepared.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_orded,
            this.Name,
            this.Type,
            this.Quantity,
            this.State});
            this.dataGridView1.Location = new System.Drawing.Point(21, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(378, 483);
            this.dataGridView1.TabIndex = 2;
            // 
            // id_orded
            // 
            this.id_orded.HeaderText = "ID";
            this.id_orded.Name = "id_orded";
            this.id_orded.ReadOnly = true;
            this.id_orded.Width = 43;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 60;
            // 
            // Type
            // 
            this.Type.HeaderText = "Shushi Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 91;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 71;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 57;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Prepare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_prep,
            this.Name_Prep,
            this.type_prep,
            this.qt_prep,
            this.state_prep});
            this.dataGridView2.Location = new System.Drawing.Point(415, 50);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(373, 483);
            this.dataGridView2.TabIndex = 4;
            // 
            // id_prep
            // 
            this.id_prep.HeaderText = "ID";
            this.id_prep.Name = "id_prep";
            this.id_prep.ReadOnly = true;
            this.id_prep.Width = 43;
            // 
            // Name_Prep
            // 
            this.Name_Prep.HeaderText = "Name";
            this.Name_Prep.Name = "Name_Prep";
            this.Name_Prep.ReadOnly = true;
            this.Name_Prep.Width = 60;
            // 
            // type_prep
            // 
            this.type_prep.HeaderText = "Sushu Type";
            this.type_prep.Name = "type_prep";
            this.type_prep.ReadOnly = true;
            this.type_prep.Width = 89;
            // 
            // qt_prep
            // 
            this.qt_prep.HeaderText = "Quantity";
            this.qt_prep.Name = "qt_prep";
            this.qt_prep.ReadOnly = true;
            this.qt_prep.Width = 71;
            // 
            // state_prep
            // 
            this.state_prep.HeaderText = "State";
            this.state_prep.Name = "state_prep";
            this.state_prep.ReadOnly = true;
            this.state_prep.Width = 57;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(698, 547);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ready";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders being prepared";
            // 
            // PrepRoom
            // 
            this.ClientSize = new System.Drawing.Size(805, 609);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  public void refreshOrdersList(DataGridView dg, List<Order> ls)
    {

        dg.Rows.Clear();

        foreach (Order o in ls)
        {

            string[] tmp = {o.id.ToString(), o.client.name, o.type.ToString(), o.quantity.ToString(), o.state};
            dg.Rows.Add(tmp);
        }
    
    }

  private void button1_Click(object sender, EventArgs e)
  {
      string tmp = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
      ordersList.setOrderPreparing(tmp);
      
  }

  private void button2_Click(object sender, EventArgs e)
  {
      string tmp = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
      ordersList.setOrderReady(tmp);
  }

}



