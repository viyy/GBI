using System;
using System.Collections.Generic;

namespace Geekbrains {
    /// <summary>
    /// Модель инвентаря персонажа
    /// </summary>
    /// <see cref="BaseModel"/>
    public class InventoryModel : BaseModel
    {
        /// <summary>
        /// Карта списков содержимого инвентаря <br/>
        /// Все вещи рассортированы по типу
        /// </summary>
        /// <see cref="Type"/> <br/>
        /// <see cref="List{T}"/> <br/>
        /// <see cref="InventoryItemController"/>
        private Dictionary<Type, List<InventoryItemController>> _items;

        public InventoryModel()
        {
            _items = new Dictionary<Type, List<InventoryItemController>>();
        }

        /// <summary>
        /// Метод добавления вещи в инвентарь
        /// </summary>
        /// <param name="item">Объект вещи</param>
        /// <typeparam name="T">Тип вещи, наследуемый от InventoryItemController</typeparam>
        /// <see cref="InventoryItemController"/>
        public void AddItem<T>(T item)
            where T : InventoryItemController
        {
            var type = typeof(T);

            if ( _items.ContainsKey(type) ) {
                _items[type].Add(item);
            } else {
                _items.Add(type, new List<InventoryItemController> { item });
            }
        }
    }
}