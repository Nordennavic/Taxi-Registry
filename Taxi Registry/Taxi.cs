using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Registry
{
    public class Taxi
    {
        /// <summary>
        /// Водитель 
        /// </summary>
        public Driver driver;

        /// <summary>
        /// Модель и бренд автомобиля
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Цвет машины
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Свидетельство о регистрации ТС  XXXX №XXXXXX
        /// </summary>
        public int VehicleLicense { get; set; }

        /// <summary>
        /// Фотография автомобиля
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Номер автомобиля
        /// </summary>
        public string RegistrationPlate { get; set; }

        /// <summary>
        /// Наличие детского кресла
        /// </summary>
        public bool BabyChair { get; set; }

        /// <summary>
        /// Тип такси
        /// </summary>
        public enum TaxiType
        {
            Econom,
            Comfort,
            Business,
            Cargo
        }

        /// <summary>
        /// Список заказов
        /// </summary>
        public List<Order> Orders { get; set; }
    }

    public class Driver
    {
        /// <summary>
        /// Имя водителя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения водителя
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Номер водительских прав
        /// </summary>
        public int LicenseNumber { get; set; }

        /// <summary>
        /// Средняя оценка от всех поездок. Считается,
        /// при наличии выполненных заказов.
        /// </summary>
        public double DriverRating { get; private set; }
        
        /// <summary>
        /// Количество выполненных заказов
        /// </summary>
        public int CompletedOrdersCount { get; private set; }
    }

    public class Order
    {
        /// <summary>
        /// Назначенное время
        /// </summary>
        public DateTime RideTime { get; set; }

        /// <summary>
        /// Откуда
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Куда
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Дополнительные условия поездки
        /// </summary>
        public bool AdditionalTerms { get; set; }

        /// <summary>
        /// Оценка поездки пассажиром
        /// </summary>
        public enum RideRating
        {
            none,
            One,
            Two,
            Three,
            Four,
            Five
        }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public enum OrderStatus
        {
            Cancelled,
            Completed,
        }
    }

}