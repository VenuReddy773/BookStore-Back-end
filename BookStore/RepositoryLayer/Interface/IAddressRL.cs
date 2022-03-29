using ModelLayer.Service.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        bool AddAddress(AddressModel address);
        bool UpdateAddress(AddressModel address);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressbyUserid(int userId);
        bool DeleteAddress(int addressId);
    }
}
