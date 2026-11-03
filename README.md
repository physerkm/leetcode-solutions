# LeetCode Solutions

LeetCode'da çözdüğüm soruların C# çözümleri.

## Çözümler

| # | Soru | Zorluk | Çözüm |
|---|------|--------|-------|
| 20 | [Valid Parentheses](https://leetcode.com/problems/valid-parentheses/) | Easy | [C#](src/LeetCode/Problems/P0020_ValidParentheses/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0020_ValidParentheses/) |
| 70 | [Climbing Stairs](https://leetcode.com/problems/climbing-stairs/) | Easy | [C#](src/LeetCode/Problems/P0070_ClimbingStairs/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0070_ClimbingStairs/) |
| 74 | [Search a 2D Matrix](https://leetcode.com/problems/search-a-2d-matrix/) | Medium | [C#](src/LeetCode/Problems/P0074_SearchA2DMatrix/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0074_SearchA2DMatrix/) |
| 128 | [Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/) | Medium | [C#](src/LeetCode/Problems/P0128_LongestConsecutiveSequence/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0128_LongestConsecutiveSequence/) |
| 206 | [Reverse Linked List](https://leetcode.com/problems/reverse-linked-list/) | Easy | [C#](src/LeetCode/Problems/P0206_ReverseLinkedList/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0206_ReverseLinkedList/) |
| 238 | [Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/) | Medium | [C#](src/LeetCode/Problems/P0238_ProductOfArrayExceptSelf/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0238_ProductOfArrayExceptSelf/) · [Video](https://physerkm.github.io/leetcode-solutions/P0238_ProductOfArrayExceptSelf/#video) |
| 448 | [Find All Numbers Disappeared in an Array](https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/) | Easy | [C#](src/LeetCode/Problems/P0448_FindAllNumbersDisappearedInAnArray/Solution.cs) · [Adım adım](https://physerkm.github.io/leetcode-solutions/P0448_FindAllNumbersDisappearedInAnArray/) |

## Nasıl çalıştırılır

Gereksinimler: [.NET 10 SDK](https://dotnet.microsoft.com/download) ve Visual Studio 2026 (ya da C# Dev Kit eklentili VS Code).

**Visual Studio ile**

1. `LeetCode.slnx` dosyasına çift tıkla.
2. **Test → Test Gezgini** (Test Explorer) menüsünü aç.
3. Ağaçta istediğin soruyu bul (örneğin `P0074_SearchA2DMatrix`), sağ tıkla ve **Çalıştır**'ı seç.

Yeşil tik testlerin geçtiğini, kırmızı çarpı geçmediğini gösterir.

**Terminalden**

Repo klasöründe:

```bash
dotnet test                                       # tüm sorular
dotnet test --filter "FullyQualifiedName~P0074"   # tek bir soru
```

## Proje yapısı

```
src/LeetCode/
├── Common/                 # LeetCode'un hazır verdiği ListNode, TreeNode
└── Problems/
    └── P0074_SearchA2DMatrix/
        └── Solution.cs     # çözüm
tests/LeetCode.Tests/
├── Helpers/                # [1,2,3] gibi dizileri ListNode/TreeNode'a çeviren yardımcılar
└── Problems/
    └── P0074_SearchA2DMatrix/
        └── SolutionTests.cs  # çözümün testleri
docs/
├── index.html              # sitenin ana sayfası: anlatımların listesi
└── P0074_SearchA2DMatrix/
    └── index.html          # adım adım anlatım (GitHub Pages'te yayınlanır)
```

Her soru kendi namespace'inde (`LeetCode.Problems.P0074_SearchA2DMatrix`) durduğu için tüm sınıflar, LeetCode'daki gibi `Solution` adını kullanabilir.

## Yeni soru ekleme

1. `src/LeetCode/Problems/P<numara>_<Ad>/Solution.cs` dosyasını oluştur. Numarayı 4 haneye tamamla, örneğin `P0020_ValidParentheses`.
2. Dosyanın ilk satırına klasörle aynı namespace'i yaz: `namespace LeetCode.Problems.P0020_ValidParentheses;`
3. LeetCode'daki kodu yapıştırıp çöz. Gönderirken namespace satırını kopyalama, sadece `Solution` sınıfını al.
4. `tests/LeetCode.Tests/Problems/` altına aynı adla bir test ekle.
5. Yukarıdaki tabloya bir satır ekle.
