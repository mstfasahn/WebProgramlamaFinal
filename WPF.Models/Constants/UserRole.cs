using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Constants
{
    public enum UserRole
    {
        Admin=1, //Her þey serbest
        Customer=2, //Düz müþteri satýn al, sipariþini izle...
        BusinessAccount = 3, //Kendi adýna kitap ekle, sil, satýþ yap vb.
        Guest=4 //No session
    }
}
