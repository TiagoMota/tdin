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

public class DeliveryRoom : Form
{
    private Label label2;
    private DataGridView dataGridView1;
    private Label label3;
    private DataGridView dataGridView2;
    private Button escolher;
    private Button entregue;
    private Label nameTeam;
    private string TeamID {get; set; }
    EventIntermediate inter;
    private DataGridViewTextBoxColumn id_Ready;
    private DataGridViewTextBoxColumn nameDelivery;
    private DataGridViewTextBoxColumn addressDelivery;
    private DataGridViewTextBoxColumn state_Ready;
    private DataGridViewTextBoxColumn id_Delivering;
    private DataGridViewTextBoxColumn nameChoose;
    private DataGridViewTextBoxColumn addressChoose;
    private DataGridViewTextBoxColumn state_Delivering;
    IOrders ordersList;

    DeliveryRoom()
    {
        Text = "Delivery Room";
        try
        {
            RemotingConfiguration.Configure("DeliveryRoom.exe.config", false);
            inter = new EventIntermediate();
            inter.ReadyOrder += OnReadyOrder;
            inter.DeliveringOrder += OnDeliveringOrder;
            inter.FinalizingOrder += OnFinalizingOrder;
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            ordersList.ReadyOrder += inter.FireReadyOrder;
            ordersList.DeliveringOrder += inter.FireDeliveringOrder;
            ordersList.FinalizingOrder += inter.FireFinalizingOrder;
            TeamID = (ordersList.GetDeliveryTeams().Count + 1).ToString();
            ordersList.AddDeliveryTeam(TeamID);
            InitializeComponent();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Close();
        }
    }

    public void OnReadyOrder()
    {
        refreshList(dataGridView1, ordersList.GetReadyOrders());
    }

    public void OnDeliveringOrder()
    {
        refreshList(dataGridView1, ordersList.GetReadyOrders());
        refreshList_Special(dataGridView2, ordersList.GetDeliveringOrders(), TeamID);
    }

    public void OnFinalizingOrder()
    {
        refreshList_Special(dataGridView2, ordersList.GetDeliveringOrders(), TeamID);
    }

    
    static void Main(string[] args)
    {

        Application.Run(new DeliveryRoom());
    }

    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[DeliveryRoom]: InitilizeLifetimeService");
        return null;
    }


    

    private void InitializeComponent()
    {
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.escolher = new System.Windows.Forms.Button();
            this.entregue = new System.Windows.Forms.Button();
            this.nameTeam = new System.Windows.Forms.Label();
            this.id_Ready = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_Ready = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_Delivering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_Delivering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ready Orders";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Ready,
            this.nameDelivery,
            this.addressDelivery,
            this.state_Ready});
            this.dataGridView1.Location = new System.Drawing.Point(23, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(452, 428);
            this.dataGridView1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Orders being delivered";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Delivering,
            this.nameChoose,
            this.addressChoose,
            this.state_Delivering});
            this.dataGridView2.Location = new System.Drawing.Point(491, 64);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(452, 428);
            this.dataGridView2.TabIndex = 3;
            // 
            // escolher
            // 
            this.escolher.Location = new System.Drawing.Point(379, 498);
            this.escolher.Name = "escolher";
            this.escolher.Size = new System.Drawing.Size(96, 42);
            this.escolher.TabIndex = 4;
            this.escolher.Text = "Deliver";
            this.escolher.UseVisualStyleBackColor = true;
            this.escolher.Click += new System.EventHandler(this.button1_Click);
            // 
            // entregue
            // 
            this.entregue.Location = new System.Drawing.Point(854, 498);
            this.entregue.Name = "entregue";
            this.entregue.Size = new System.Drawing.Size(89, 42);
            this.entregue.TabIndex = 5;
            this.entregue.Text = "Done";
            this.entregue.UseVisualStyleBackColor = true;
            this.entregue.Click += new System.EventHandler(this.button2_Click);
            // 
            // nameTeam
            // 
            this.nameTeam.AutoSize = true;
            this.nameTeam.Location = new System.Drawing.Point(20, 9);
            this.nameTeam.Name = "nameTeam";
            this.nameTeam.Size = new System.Drawing.Size(65, 13);
            this.nameTeam.TabIndex = 6;
            this.nameTeam.Text = "Team number: " + TeamID;
            // 
            // id_Ready
            // 
            this.id_Ready.HeaderText = "ID";
            this.id_Ready.Name = "id_Ready";
            this.id_Ready.ReadOnly = true;
            // 
            // nameDelivery
            // 
            this.nameDelivery.HeaderText = "Name";
            this.nameDelivery.Name = "nameDelivery";
            this.nameDelivery.ReadOnly = true;
            // 
            // addressDelivery
            // 
            this.addressDelivery.HeaderText = "Address";
            this.addressDelivery.Name = "addressDelivery";
            this.addressDelivery.ReadOnly = true;
            // 
            // state_Ready
            // 
            this.state_Ready.HeaderText = "State";
            this.state_Ready.Name = "state_Ready";
            this.state_Ready.ReadOnly = true;
            // 
            // id_Delivering
            // 
            this.id_Delivering.HeaderText = "ID";
            this.id_Delivering.Name = "id_Delivering";
            this.id_Delivering.ReadOnly = true;
            // 
            // nameChoose
            // 
            this.nameChoose.HeaderText = "Name";
            this.nameChoose.Name = "nameChoose";
            this.nameChoose.ReadOnly = true;
            // 
            // addressChoose
            // 
            this.addressChoose.HeaderText = "Address";
            this.addressChoose.Name = "addressChoose";
            this.addressChoose.ReadOnly = true;
            // 
            // state_Delivering
            // 
            this.state_Delivering.HeaderText = "State";
            this.state_Delivering.Name = "state_Delivering";
            this.state_Delivering.ReadOnly = true;
            // 
            // DeliveryRoom
            // 
            this.ClientSize = new System.Drawing.Size(957, 552);
            this.Controls.Add(this.nameTeam);
            this.Controls.Add(this.entregue);
            this.Controls.Add(this.escolher);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "DeliveryRoom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        string tmp = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
        ordersList.setOrderDelivering(tmp, TeamID);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string tmp = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
        ordersList.setOrderDone(tmp);
    }

    public void refreshList(DataGridView dg, List<Order> ls)
    {

        dg.Rows.Clear();

        foreach (Order o in ls)
        {

            string[] tmp = { o.id.ToString(), o.client.name, o.client.address };
            dg.Rows.Add(tmp);
        }

    }

    public void refreshList_Special(DataGridView dg, List<Order> ls, string team)
    {

        dg.Rows.Clear();

        foreach (Order o in ls)
        {
            if (o.deliveryTeamAssigned == team)
            {
                string[] tmp = { o.id.ToString(), o.client.name, o.client.address };
                dg.Rows.Add(tmp);
            }
        }

    }
}

