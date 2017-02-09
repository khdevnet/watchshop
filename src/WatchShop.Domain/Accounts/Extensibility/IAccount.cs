﻿using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface IAccount
    {
        bool IsRegistered(string email);

        void Register(Customer customer);

        void Update(Customer customer);

        void UnRegister(string email);
    }
}