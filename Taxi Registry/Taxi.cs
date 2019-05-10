using System;
using System.Collections.Generic;

namespace Taxi_Registry
{
    public class Taxi
    {
        /// <summary>
        /// Водитель 
        /// </summary>
        public Driver Driver;

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
        /// Тип этого такси
        /// </summary>
        public TaxiType Type;

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
        /// Фамилия водителя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество водителя
        /// </summary>
        public string MiddleName { get; set; }

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
        public double DriverRating { get; set; }
        
        /// <summary>
        /// Количество выполненных заказов
        /// </summary>
        public int CompletedOrdersCount { get; set; }
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
        /// Оценка пассажира
        /// </summary>
        public RideRating Rating { get; set; }

        /// <summary>
        /// Виды оценок 
        /// </summary>
        public enum RideRating
        {
            none = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Виды статуса
        /// </summary>
        public enum OrderStatus
        {
            Cancelled,
            Completed,
        }
        public override string ToString()
        {
            return $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(RideTime)}: {RideTime}, {nameof(AdditionalTerms)}: {AdditionalTerms}, {nameof(Status)}: {Status}, {nameof(Rating)}: {Rating}";
        }
    }

    /// <summary>
    /// Существующие типы такси
    /// </summary>
    public enum TaxiType
    {
        Econom,
        Comfort,
        Business,
        Cargo
    }

}