# C# コーディング規約

本ドキュメントは `.editorconfig` に基づく C# コーディング規約を定義します。

---

## 1. 基本フォーマット

### 1.1 インデントと間隔

| 項目 | 設定 |
|------|------|
| インデントスタイル | **スペース** |
| インデントサイズ | **4** |
| タブ幅 | **4** |

### 1.2 改行設定

| 項目 | 設定 |
|------|------|
| 改行コード | **CRLF** (Windows形式) |
| ファイル末尾の改行 | **挿入しない** |

---

## 2. 言語キーワードと型の使用

### 2.1 `this.` 修飾子

`this.` 修飾子は**使用しない**。

```csharp
// ✅ 良い例
name = value;

// ❌ 悪い例
this.name = value;
```

### 2.2 組み込み型 vs BCL型

ローカル変数、パラメーター、メンバーには**言語キーワード**を使用する。

```csharp
// ✅ 良い例
int count = 0;
string name = "";

// ❌ 悪い例
Int32 count = 0;
String name = "";
```

---

## 3. `var` の使用

| シナリオ | 設定 |
|----------|------|
| 組み込み型 | **明示的な型を使用** |
| 型が明らかな場合 | **var を使用可** |
| その他の場合 | **明示的な型を使用** |

```csharp
// ✅ 良い例
int count = 10;                           // 組み込み型は明示
string name = "test";                     // 組み込み型は明示
var customer = new Customer();            // 型が明らかな場合は var
var items = new List<string>();           // 型が明らかな場合は var

// ❌ 悪い例
var count = 10;                           // 組み込み型に var は使わない
Customer customer = new Customer();       // 型が明らかな場合は var を推奨
```

---

## 4. 修飾子

### 4.1 アクセス修飾子

インターフェース以外のメンバーには**アクセス修飾子を明示**する。

```csharp
// ✅ 良い例
private int _count;
public void DoSomething() { }

// ❌ 悪い例
int _count;                    // アクセス修飾子がない
void DoSomething() { }         // アクセス修飾子がない
```

### 4.2 修飾子の順序

修飾子は以下の順序で記述する：

```
public, private, protected, internal, file, static, extern, new, virtual, abstract, sealed, override, readonly, unsafe, required, volatile, async
```

### 4.3 静的メンバーの推奨

- 匿名関数: **静的を推奨**
- ローカル関数: **静的を推奨**
- 構造体: **readonly を推奨**

---

## 5. 式形式メンバー (Expression-bodied Members)

| メンバー種別 | 設定 |
|-------------|------|
| プロパティ | **使用する** |
| アクセサー | **使用する** |
| インデクサー | **使用する** |
| ラムダ式 | **使用する** |
| コンストラクター | **使用しない** |
| メソッド | **使用しない** |
| 演算子 | **使用しない** |
| ローカル関数 | **使用しない** |

```csharp
// ✅ プロパティ - 式形式を使用
public string Name => _name;
public int Count { get => _count; set => _count = value; }

// ✅ コンストラクター - ブロック形式を使用
public MyClass(string name)
{
    _name = name;
}

// ✅ メソッド - ブロック形式を使用
public void Process()
{
    // 処理
}
```

---

## 6. パターンマッチング

パターンマッチングを**積極的に使用**する。

```csharp
// ✅ 良い例
if (obj is string text) { }
if (obj is not null) { }

// ❌ 悪い例
if (obj is string)
{
    var text = (string)obj;
}
if (!(obj is null)) { }
```

### Switch 式

switch 式を**推奨**する。

```csharp
// ✅ 良い例
var result = status switch
{
    Status.Active => "有効",
    Status.Inactive => "無効",
    _ => "不明"
};
```

---

## 7. Null チェック

### 7.1 条件付きデリゲート呼び出し

```csharp
// ✅ 良い例
EventHandler?.Invoke(this, args);

// ❌ 悪い例
if (EventHandler != null)
{
    EventHandler(this, args);
}
```

### 7.2 Null 伝播演算子

```csharp
// ✅ 良い例
var length = text?.Length;

// ❌ 悪い例
var length = text != null ? text.Length : (int?)null;
```

### 7.3 Null 合体演算子

```csharp
// ✅ 良い例
var name = input ?? "default";

// ❌ 悪い例
var name = input != null ? input : "default";
```

### 7.4 is null チェック

```csharp
// ✅ 良い例
if (obj is null) { }

// ❌ 悪い例
if (ReferenceEquals(obj, null)) { }
```

---

## 8. コードブロック

### 8.1 ブレース

ブレースは**常に使用**する。

```csharp
// ✅ 良い例
if (condition)
{
    DoSomething();
}

// ❌ 悪い例
if (condition)
    DoSomething();
```

### 8.2 using ステートメント

シンプルな using ステートメントを**推奨**する。

```csharp
// ✅ 良い例
using var stream = new FileStream(path, FileMode.Open);
// 処理

// 👌 許容（必要な場合）
using (var stream = new FileStream(path, FileMode.Open))
{
    // 処理
}
```

### 8.3 名前空間

**ファイルスコープ名前空間**を使用する。

```csharp
// ✅ 良い例
namespace MyApp.Services;

public class MyService { }

// ❌ 悪い例
namespace MyApp.Services
{
    public class MyService { }
}
```

### 8.4 トップレベルステートメント

トップレベルステートメントを**推奨**する（Program.cs など）。

### 8.5 プライマリコンストラクター

プライマリコンストラクターを**推奨**する。

```csharp
// ✅ 良い例 (C# 12+)
public class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
}
```

---

## 9. コレクション式

コレクション式を**推奨**する。

```csharp
// ✅ 良い例
List<int> numbers = [1, 2, 3, 4, 5];
int[] array = [1, 2, 3];

// ❌ 悪い例
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int[] array = new int[] { 1, 2, 3 };
```

---

## 10. その他の式レベル設定

| 項目 | 推奨 |
|------|------|
| オブジェクト初期化子 | **使用する** |
| コレクション初期化子 | **使用する** |
| 自動プロパティ | **使用する** |
| 明示的なタプル名 | **使用する** |
| 推論されたタプル名 | **使用する** |
| 複合代入演算子 | **使用する** |
| インデックス演算子 (^) | **使用する** |
| 範囲演算子 (..) | **使用する** |
| throw 式 | **使用する** |
| インライン変数宣言 | **使用する** |
| 暗黙的 new() | **型が明らかな場合に使用** |

```csharp
// ✅ オブジェクト初期化子
var person = new Person { Name = "John", Age = 30 };

// ✅ インデックス・範囲演算子
var last = items[^1];
var subset = items[1..^1];

// ✅ throw 式
var name = input ?? throw new ArgumentNullException(nameof(input));

// ✅ インライン変数宣言
if (int.TryParse(text, out var number)) { }

// ✅ 暗黙的 new()
Person person = new() { Name = "John" };
```

---

## 11. フィールド設定

### 11.1 readonly フィールド

変更されないフィールドには**readonly を使用**する。

```csharp
// ✅ 良い例
private readonly ILogger _logger;

// ❌ 悪い例
private ILogger _logger;  // 変更されないなら readonly にする
```

### 11.2 未使用パラメーター

未使用のパラメーターは**警告対象**とする。

---

## 12. C# 書式ルール

### 12.1 改行（ブレースの配置）

**Allman スタイル**を使用する。すべての要素で開きブレースを**新しい行に配置**。

```csharp
// ✅ Allman スタイル
if (condition)
{
    DoSomething();
}
else
{
    DoOther();
}

public class MyClass
{
    public void Method()
    {
        // 処理
    }
}
```

### 12.2 制御構文の改行

| 要素 | 設定 |
|------|------|
| else | **新しい行** |
| catch | **新しい行** |
| finally | **新しい行** |

### 12.3 インデント

| 項目 | 設定 |
|------|------|
| ブロック内容 | インデントする |
| ブレース | インデントしない |
| case 内容 | インデントする |
| switch ラベル | インデントする |
| ラベル | 現在より1つ少なく |

### 12.4 スペース

| 項目 | 設定 |
|------|------|
| キャスト後 | スペースなし |
| 制御フロー キーワード後 | スペースあり |
| 二項演算子周り | 前後にスペース |
| カンマ後 | スペースあり |
| セミコロン後 (for文) | スペースあり |
| 継承句のコロン前後 | スペースあり |
| メソッド名と括弧の間 | スペースなし |

```csharp
// ✅ 正しいスペース
var result = (int)value;                    // キャスト後スペースなし
if (condition) { }                          // キーワード後スペースあり
var sum = a + b;                            // 演算子前後スペースあり
Method(a, b, c);                            // カンマ後スペースあり
for (int i = 0; i < 10; i++) { }           // セミコロン後スペースあり
class Child : Parent { }                    // コロン前後スペースあり
DoSomething();                              // メソッド名と括弧の間スペースなし
```

---

## 13. 命名規則

### 13.1 命名スタイル

| 要素 | スタイル | 例 |
|------|----------|-----|
| クラス、構造体、列挙型 | PascalCase | `CustomerService`, `OrderStatus` |
| インターフェース | I + PascalCase | `IRepository`, `IService` |
| メソッド | PascalCase | `GetCustomer`, `ProcessOrder` |
| プロパティ | PascalCase | `Name`, `IsActive` |
| イベント | PascalCase | `ItemChanged`, `Completed` |
| public フィールド | PascalCase | `MaxValue` |
| private/internal フィールド | _ + camelCase | `_name`, `_orderService` |
| パラメーター | camelCase | `customerId`, `orderDate` |
| ローカル変数 | camelCase | `count`, `itemList` |

### 13.2 命名例

```csharp
public interface ICustomerRepository     // インターフェース: I + PascalCase
{
    Customer GetById(int customerId);    // メソッド: PascalCase, パラメーター: camelCase
}

public class CustomerService             // クラス: PascalCase
{
    private readonly ICustomerRepository _repository;  // private フィールド: _camelCase
    
    public string ServiceName { get; }                 // プロパティ: PascalCase
    public event EventHandler CustomerSaved;           // イベント: PascalCase
    
    public Customer GetCustomer(int id)                // メソッド: PascalCase
    {
        var customer = _repository.GetById(id);        // ローカル変数: camelCase
        return customer;
    }
}
```

---

## 14. using ディレクティブ

| 項目 | 設定 |
|------|------|
| 配置場所 | **名前空間の外側** |
| System 名前空間の優先 | **しない** |
| グループ分け | **しない** |

```csharp
// ✅ 良い例
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MyApp.Services;

public class MyService { }
```

---

## 付録: 設定の重大度

本規約の各項目は以下の重大度で適用されます：

- **suggestion**: 推奨（IDE で提案として表示）
- 明示的なエラーや警告は設定されていないため、柔軟に運用可能

---

*本ドキュメントは `.editorconfig` から自動生成されています。*
