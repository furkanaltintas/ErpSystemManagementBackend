using ErpSystemManagement.Domain.Repositories;

namespace ErpSystemManagement.Domain.Entities.ValueObjects;

public class OrderNumberGenerator(IOrderRepository orderRepository)
{
    public async Task<string> GenerateNextOrderNumberAsync(CancellationToken cancellationToken)
    {
        string prefix = "FA";
        string datePart = DateTime.UtcNow.ToString("yyMMdd");

        // En son ki OrderNumber'ı veritabanından al
        string? lastOrderNumber = await orderRepository.GetLastOrderNumberAsync(cancellationToken);

        int nextNumber = 1; // İlk sipariş için

        if (!string.IsNullOrEmpty(lastOrderNumber))
        {
            //FA250402123 -> Sondaki 3 basamaklı kısmı al ve arttır
            string lastNumberPart = lastOrderNumber.Substring(8);
            nextNumber = int.Parse(lastNumberPart) + 1;
        }

        // Yeni OrderNumber üret
        return $"{prefix}{datePart}{nextNumber:D3}"; // Örn: FA250402124
    }
}

// FA250402123
//FA → Firma kodu / sabit ön ek
//25 → Yılın son iki hanesi(2025)
//04 → Ay(Nisan)
//02 → Gün(2)
//123 → Rastgele üretilen sayı