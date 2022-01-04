using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagerWinform.Views
{
    class ViewRoom : Button
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int amount { get; set; }
        public ViewRoom() { }
        public void initial(string name)
        {
            this.name = name;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Size = new System.Drawing.Size(125, 90);
            this.TabIndex = 1;
            this.UseVisualStyleBackColor = false;

            if (amount < 30 || amount > 35)
            {
                this.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                this.BackColor = System.Drawing.Color.LimeGreen;
            }

            this.Text = this.name + "\n" + this.amount + " Thí sinh";
        }

        public void apterUpdateNameOrAmount()
        {
            if (amount < 30 || amount > 35)
            {
                this.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                this.BackColor = System.Drawing.Color.LimeGreen;
            }
            this.Text = this.name + "\n" + this.amount + " Thí sinh";
        }


        // Button cc = new Button();
        // cc.BackColor = System.Drawing.Color.LimeGreen;
        // cc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        // cc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        // cc.Name = "button1";
        // cc.Size = new System.Drawing.Size(125, 90);
        // cc.TabIndex = 1;
        // cc.Text = "A2001\n35 Thí sinh\Chưa có người coi thi";
        // cc.UseVisualStyleBackColor = false;
    }
}
