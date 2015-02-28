using System;

public class Delivery
{
    private DateTime contractDate;
    private DeliveryItem startDate;
    private DeliveryItem complextDate;
    private DeliveryItem shipmetDate;
    private DeliveryItem deliveryDate;

    public Delivery(DateTime contractDate)
    {
        this.contractDate = contractDate;
        DivisionIntoStages();
    }

    //Разбиение даты в контракте на временные отрезки для каждого этапа
    public void DivisionIntoStages()
    {
        
    }
}
