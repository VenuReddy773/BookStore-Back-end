using BusinessLayer.Interface;
using ModelLayer.Service.AddressModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public bool AddAddress(AddressModel address)
        {
            try
            {
                return this.addressRL.AddAddress(address);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteAddress(int addressId)
        {
            try
            {
                return this.addressRL.DeleteAddress(addressId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<AddressModel> GetAddressbyUserid(int userId)
        {
            try
            {
                return this.addressRL.GetAddressbyUserid(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressModel> GetAllAddress()
        {
            try
            {
                return this.addressRL.GetAllAddress();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateAddress(AddressModel address)
        {
            try
            {
                return this.addressRL.UpdateAddress(address);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
