using System;

public enum DeliveryStatus 
{
    Expected,   //Ожидается
    Performed,  //Выполняется
    Completed   //Завершено
}

public class DeliveryItem
{
    private DeliveryStatus status;
    private DateTime date;

    public DeliveryItem(DateTime data)
    {
        this.date = data;
        this.status = DeliveryStatus.Expected;
    }
}
