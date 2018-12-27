using System;
using System.Collections.Generic;

namespace Geekbrains {
    public class InventoryModel : BaseModel
    {
        private Dictionary<Type, List<InventoryItemController>> _items;

        public InventoryModel()
        {
            _items = new Dictionary<Type, List<InventoryItemController>>();
        }

        public void AddItem<T>(T item)
            where T : InventoryItemController
        {
            var type = typeof(T);

            if ( _items.ContainsKey(type) ) {
                _items[type].Add(item);
            } else {
                _items.Add(type, new List<InventoryItemController>() { item });
            }
        }
    }
}