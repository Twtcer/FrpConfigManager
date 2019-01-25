using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using FrpConfigManager.Model; 

namespace FrpConfigManager
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }



        private void FrmTest_Load(object sender, EventArgs e)
        {
            var list = GetModels();
            var downList = new Dictionary<string, string>();
            list.ForEach(a =>
            {
                downList.Add(a.Name, a.FullName);
            });
            cbbModels.DataSource = new BindingSource(downList,null);
            cbbModels.DisplayMember = "Key";
            cbbModels.ValueMember = "Value"; 
        }

        public List<Type> GetModels()
        { 
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();

            List<Type> typeList = new List<Type>();
            foreach (Type t in types)
            {
                if (new List<Type>(t.GetInterfaces()).Contains(typeof(IFrpConfig)))
                {
                    typeList.Add(t);
                }
            }

            return typeList;
        }

        private void cbbModels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
