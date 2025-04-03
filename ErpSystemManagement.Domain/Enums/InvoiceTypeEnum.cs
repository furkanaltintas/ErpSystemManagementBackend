namespace ErpSystemManagement.Domain.Enums;

public enum InvoiceTypeEnum
{
    Purchase = 1, // Alış Faturası
    Sales = 2 // Satış Faturası
}

public static class InvoiceEnum
{
    public static string InvoiceTypeName(int typeValue)
    {
        // Enum.IsDefined Nedir ?
        // Enum.IsDefined(Type, Object) metodu, bir değerin belirli bir enum türü içinde tanımlı olup olmadığını kontrol eder.

        if (Enum.IsDefined(typeof(InvoiceTypeEnum), typeValue))
            return ((InvoiceTypeEnum)typeValue).ToString();
        else
            return "Unknown"; // Geçersiz bir değer gelirse
    }
}