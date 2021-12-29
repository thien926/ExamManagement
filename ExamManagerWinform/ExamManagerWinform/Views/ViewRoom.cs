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
        public string name { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int amount { get; set; }
        public int teacherIdOne { get; set; }
        public int teacherIdTwo { get; set; }
        public ViewRoom() { }
        public void initial(string text)
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Size = new System.Drawing.Size(125, 90);
            this.TabIndex = 1;
            this.Text = text;
            this.UseVisualStyleBackColor = false;

            if(teacherIdOne <= 0 || teacherIdTwo <= 0) {
                this.BackColor = System.Drawing.Color.Crimson;
            }
            else {
                this.BackColor = System.Drawing.Color.LimeGreen;
            }
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
