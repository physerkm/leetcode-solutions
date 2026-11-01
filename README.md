# LeetCode Solutions

LeetCode'da çözdüğüm soruların C# çözümleri.

## Çözümler

| # | Soru | Zorluk | Çözüm |
|---|------|--------|-------|
| 1 | [Two Sum](https://leetcode.com/problems/two-sum/) | Easy | [C#](src/LeetCode/Problems/P0001_TwoSum/Solution.cs) |
| 74 | [Search a 2D Matrix](https://leetcode.com/problems/search-a-2d-matrix/) | Medium | [C#](src/LeetCode/Problems/P0074_SearchA2DMatrix/Solution.cs) |

## Proje yapısı

```
src/LeetCode/
├── Common/                 # LeetCode'un hazır verdiği ListNode, TreeNode
└── Problems/
    └── P0001_TwoSum/
        └── Solution.cs
tests/LeetCode.Tests/
├── Helpers/                # [1,2,3] gibi dizileri ListNode/TreeNode'a çeviren yardımcılar
└── Problems/
    └── P0001_TwoSum/
        └── SolutionTests.cs
```

Her soru kendi namespace'inde (`LeetCode.Problems.P0001_TwoSum`) durduğu için tüm sınıflar, LeetCode'daki gibi `Solution` adını kullanabilir.

## Yeni soru ekleme

1. `src/LeetCode/Problems/P<numara>_<Ad>/Solution.cs` dosyasını oluştur. Numarayı 4 haneye tamamla, örneğin `P0020_ValidParentheses`.
2. Dosyanın ilk satırına klasörle aynı namespace'i yaz: `namespace LeetCode.Problems.P0020_ValidParentheses;`
3. LeetCode'daki kodu yapıştırıp çöz. Gönderirken namespace satırını kopyalama, sadece `Solution` sınıfını al.
4. İstersen `tests/LeetCode.Tests/Problems/` altına aynı adla bir test ekle.
5. Yukarıdaki tabloya bir satır ekle.

## Testleri çalıştırma

```bash
dotnet test
```
