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
    private DataGridViewTextBoxColumn nameDelivery;
    private DataGridViewTextBoxColumn addressDelivery;
    private DataGridViewTextBoxColumn nameChoose;
    private DataGridViewTextBoxColumn addressChoose;
    private Label nameTeam;
    private Label label1;
    private string TeamID {get; set; }
    EventIntermediate inter;
    IOrders ordersList;

    DeliveryRoom()
    {
        Text = "Delivery Room";
        try
        {
            RemotingConfiguration.Configure("DeliveryRoom.exe.config", false);
            inter = new EventIntermediate();
            inter.ReadyOrder += OnReadyOrder;
            ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
            ordersList.ReadyOrder += inter.FireReadyOrder;
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
            this.nameDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nameChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escolher = new System.Windows.Forms.Button();
            this.entregue = new System.Windows.Forms.Button();
            this.nameTeam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delivery";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDelivery,
            this.addressDelivery});
            this.dataGridView1.Location = new System.Drawing.Point(23, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(243, 150);
            this.dataGridView1.TabIndex = 1;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Choose";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameChoose,
            this.addressChoose});
            this.dataGridView2.Location = new System.Drawing.Point(323, 64);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(245, 150);
            this.dataGridView2.TabIndex = 3;
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
            // escolher
            // 
            this.escolher.Location = new System.Drawing.Point(190, 241);
            this.escolher.Name = "escolher";
            this.escolher.Size = new System.Drawing.Size(75, 23);
            this.escolher.TabIndex = 4;
            this.escolher.Text = "Delivery";
            this.escolher.UseVisualStyleBackColor = true;
            this.escolher.Click += new System.EventHandler(this.button1_Click);
            // 
            // entregue
            // 
            this.entregue.Location = new System.Drawing.Point(492, 241);
            this.entregue.Name = "entregue";
            this.entregue.Size = new System.Drawing.Size(75, 23);
            this.entregue.TabIndex = 5;
            this.entregue.Text = "Done";
            this.entregue.UseVisualStyleBackColor = true;
            this.entregue.Click += new System.EventHandler(this.button2_Click);
            // 
            // nameTeam
            // 
            this.nameTeam.AutoSize = true;
            this.nameTeam.Location = new System.Drawing.Point(23, 13);
            this.nameTeam.Name = "nameTeam";
            this.nameTeam.Size = new System.Drawing.Size(65, 13);
            this.nameTeam.TabIndex = 6;
            this.nameTeam.Text = "Name Team";
            // 
            // DeliveryRoom
            // 
            this.ClientSize = new System.Drawing.Size(580, 276);
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

    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    public void refreshList(DataGridView dg, List<Order> ls)
    {

        dg.Rows.Clear();

        foreach (Order o in ls)
        {

            string[] tmp = { o.client.name, o.client.address };
            dg.Rows.Add(tmp);
        }

    }
}

