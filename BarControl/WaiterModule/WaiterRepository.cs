﻿
namespace BarControl.WaiterModule
{
    internal class WaiterRepository : RepositoryBase<Waiter> 
    {
        public WaiterRepository(List<Waiter> waiterList)
        {
            records = waiterList;
        }
    }
}
