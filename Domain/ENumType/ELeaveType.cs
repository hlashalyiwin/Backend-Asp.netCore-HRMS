//enum class for leaveType from leave table
using System.ComponentModel;
namespace Hr_Management_final_api.Domain.ENumType
{
    public enum ELeaveType : byte
    {   [Description("casuel")]
        casuel =1 ,
        [Description("medical")]
        medical =2,
        [Description("withoutpay")]
        withoutpay =3

    }
}