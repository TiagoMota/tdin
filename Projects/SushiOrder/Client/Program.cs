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

class Program : Form {

    private IOrders ordersList;
    private EventIntermediate inter;
    private Panel panel1;
    private Label label1;
    private DataGridViewTextBoxColumn Name;
    private DataGridViewTextBoxColumn Type;
    private DataGridViewTextBoxColumn Quantity;
    private DataGridViewTextBoxColumn State;
    private DataGridView dataGridView1;

    Program()
    {
        Text = "Preparation Room";
        try
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new EventIntermediate();
            inter.AddingOrder += OnAddingOrder;
            ordersList = (IOrders)RemoteNew.New(typeof(IOrders));
            ordersList.AddingOrder += inter.FireAddingOrder;
            

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Close();
        }
      }

    public void OnAddingOrder()
    {
        Console.WriteLine("Entrou AQUI!!");
        refreshAllOrdersList(ordersList.GetAllOrders());
    }



  static void Main(string[] args) {
      Application.Run(new Program());
     
  }

  private void InitializeComponent()
  {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Orders";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Type,
            this.Quantity,
            this.State});
            this.dataGridView1.Location = new System.Drawing.Point(17, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 76);
            this.dataGridView1.TabIndex = 2;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Type
            // 
            this.Type.HeaderText = "Shushi Type";
            this.Type.Name = "Type";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(482, 240);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Load += new System.EventHandler(this.Program_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  private void Program_Load(object sender, EventArgs e)
  {
     
  }

  public void refreshAllOrdersList(List<Order> ls)
    {
        foreach (Order o in ls)
            Console.WriteLine(o.Name + " | " + o.type + " | " + o.quantity + " | " + o.state);
    }

}

class RemoteNew
{
    private static Hashtable types = null;

    private static void InitTypeTable()
    {
        types = new Hashtable();
        foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            types.Add(entry.ObjectType, entry);
    }

    public static object New(Type type)
    {
        if (types == null)
            InitTypeTable();
        WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
        if (entry == null)
            throw new RemotingException("Type not found!");
        return RemotingServices.Connect(type, entry.ObjectUrl);
    }

}

