using ModelLayer.Service.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBL
    {
        bool AddAddress(AddressModel address);
        bool UpdateAddress(AddressModel address);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressbyUserid(int userId);
        bool DeleteAddress(int addressId);
    }
}
