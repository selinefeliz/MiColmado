using System;

namespace MiColmado.View
{
    public interface IfrmUserView
    {
        object Private { get; }

        void btnAdd_Click(object sender, EventArgs e);
      
        void textBox1_Enter(object sender, EventArgs e);

    }
}