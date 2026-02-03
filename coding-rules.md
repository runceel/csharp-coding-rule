# C# コーディング規約

このドキュメントは、プロジェクトの `.editorconfig` ファイルに基づいた C# コーディング規約を定義しています。

---

## 目次

1. [基本設定](#基本設定)
2. [.NET コーディング規則](#net-コーディング規則)
3. [C# コーディング規則](#c-コーディング規則)
4. [C# 書式ルール](#c-書式ルール)
5. [命名規則](#命名規則)

---

## 基本設定

### インデントと間隔

| 設定 | 値 | 説明 |
|------|-----|------|
| `indent_size` | 4 | インデントのサイズは4スペース |
| `indent_style` | space | タブではなくスペースを使用 |
| `tab_width` | 4 | タブ幅は4 |

### 改行設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `end_of_line` | crlf | 改行コードは CRLF (Windows 形式) |
| `insert_final_newline` | false | ファイル末尾に改行を挿入しない |

---

## .NET コーディング規則

### using ディレクティブの整理

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_separate_import_directive_groups` | false | using ディレクティブをグループ分けしない |
| `dotnet_sort_system_directives_first` | false | System 名前空間を先頭にソートしない |
| `file_header_template` | unset | ファイルヘッダーテンプレートは未設定 |

### this. と Me. の設定

`this.` 修飾子は以下のすべてのケースで**不要**です：

| 対象 | 設定 | 説明 |
|------|------|------|
| フィールド | `false` | `this.field` ではなく `field` を使用 |
| プロパティ | `false` | `this.Property` ではなく `Property` を使用 |
| メソッド | `false` | `this.Method()` ではなく `Method()` を使用 |
| イベント | `false` | `this.Event` ではなく `Event` を使用 |

### 言語キーワードと BCL 型の設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_style_predefined_type_for_locals_parameters_members` | true | ローカル変数、パラメータ、メンバーには言語キーワード (`int`, `string` 等) を使用 |
| `dotnet_style_predefined_type_for_member_access` | true | メンバーアクセスには言語キーワードを使用 |

```csharp
// ✅ 推奨
int count = 0;
string name = "example";

// ❌ 非推奨
Int32 count = 0;
String name = "example";
```

### かっこの設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_style_parentheses_in_arithmetic_binary_operators` | always_for_clarity | 算術演算子では明確性のため常にかっこを使用 |
| `dotnet_style_parentheses_in_other_binary_operators` | always_for_clarity | その他の二項演算子では明確性のため常にかっこを使用 |
| `dotnet_style_parentheses_in_relational_binary_operators` | always_for_clarity | 関係演算子では明確性のため常にかっこを使用 |
| `dotnet_style_parentheses_in_other_operators` | never_if_unnecessary | その他の演算子では不要ならかっこを使用しない |

```csharp
// ✅ 推奨
int result = (a + b) * c;
bool condition = (x > 0) && (y < 10);

// ❌ 非推奨
int result = a + b * c;  // 演算子の優先順位が不明確
```

### 修飾子設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_style_require_accessibility_modifiers` | for_non_interface_members | インターフェースメンバー以外はアクセシビリティ修飾子を必須とする |

```csharp
// ✅ 推奨
public class MyClass
{
    private int _field;
    public void Method() { }
}

// ❌ 非推奨
class MyClass
{
    int _field;  // アクセシビリティ修飾子がない
    void Method() { }
}
```

### 式レベルの設定

| 設定 | 推奨 | 説明 |
|------|------|------|
| `dotnet_style_coalesce_expression` | ✅ | null 合体演算子 (`??`) を使用 |
| `dotnet_style_null_propagation` | ✅ | null 条件演算子 (`?.`) を使用 |
| `dotnet_style_collection_initializer` | ✅ | コレクション初期化子を使用 |
| `dotnet_style_object_initializer` | ✅ | オブジェクト初期化子を使用 |
| `dotnet_style_explicit_tuple_names` | ✅ | 明示的なタプル名を使用 |
| `dotnet_style_prefer_auto_properties` | ✅ | 自動プロパティを優先 |
| `dotnet_style_prefer_compound_assignment` | ✅ | 複合代入演算子 (`+=`, `-=` 等) を使用 |
| `dotnet_style_prefer_conditional_expression_over_assignment` | ✅ | 条件式を代入より優先 |
| `dotnet_style_prefer_conditional_expression_over_return` | ✅ | 条件式を return より優先 |
| `dotnet_style_prefer_inferred_tuple_names` | ✅ | 推論されたタプル名を使用 |
| `dotnet_style_prefer_inferred_anonymous_type_member_names` | ✅ | 推論された匿名型メンバー名を使用 |
| `dotnet_style_prefer_is_null_check_over_reference_equality_method` | ✅ | `is null` を参照等価メソッドより優先 |
| `dotnet_style_prefer_simplified_boolean_expressions` | ✅ | 簡略化されたブール式を優先 |
| `dotnet_style_prefer_simplified_interpolation` | ✅ | 簡略化された文字列補間を優先 |
| `dotnet_style_prefer_collection_expression` | ✅ | コレクション式を優先 (型が緩く一致する場合) |

```csharp
// ✅ 推奨
var name = person?.Name ?? "Unknown";
var list = new List<int> { 1, 2, 3 };
var obj = new Person { Name = "John", Age = 30 };

// ❌ 非推奨
var name = person != null ? person.Name : "Unknown";
var list = new List<int>();
list.Add(1);
list.Add(2);
list.Add(3);
```

### フィールド設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_style_readonly_field` | true | 可能な場合は `readonly` を使用 |

```csharp
// ✅ 推奨
private readonly int _maxCount = 100;

// ❌ 非推奨
private int _maxCount = 100;  // 変更されないなら readonly にすべき
```

### 未使用パラメータ

| 設定 | 値 | 説明 |
|------|-----|------|
| `dotnet_code_quality_unused_parameters` | all | すべての未使用パラメータを警告 |

---

## C# コーディング規則

### var の使用

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_style_var_for_built_in_types` | true | 組み込み型にも `var` を使用 |
| `csharp_style_var_when_type_is_apparent` | true | 型が明確な場合は `var` を使用 |
| `csharp_style_var_elsewhere` | true | その他の場合も `var` を使用 |

**すべてのケースで `var` の使用を推奨します。**

```csharp
// ✅ 推奨
var count = 0;                           // 組み込み型にも var を使用
var name = "example";                    // 組み込み型にも var を使用
var person = new Person();               // 型が明確な場合は var を使用
var list = new List<string>();           // 型が明確な場合は var を使用
var result = GetResult();                // その他の場合も var を使用

// ❌ 非推奨
int count = 0;                           // 明示的な型指定は不要
string name = "example";                 // 明示的な型指定は不要
Person person = new Person();            // var を使用すべき
```

### 式形式のメンバー

| メンバー | 式形式を使用 | 説明 |
|----------|-------------|------|
| アクセサー | ✅ | プロパティのアクセサーに式形式を使用 |
| プロパティ | ✅ | プロパティに式形式を使用 |
| インデクサー | ✅ | インデクサーに式形式を使用 |
| ラムダ | ✅ | ラムダ式に式形式を使用 |
| コンストラクター | ❌ | コンストラクターには式形式を使用しない |
| メソッド | ❌ | メソッドには式形式を使用しない |
| ローカル関数 | ❌ | ローカル関数には式形式を使用しない |
| 演算子 | ❌ | 演算子には式形式を使用しない |

```csharp
// ✅ 推奨
public string Name { get; set; }
public int Count => _items.Count;                    // プロパティの式形式
public string this[int index] => _items[index];     // インデクサーの式形式

public void Process()                                // メソッドはブロック形式
{
    // 処理
}

// ❌ 非推奨
public void Process() => DoSomething();              // メソッドに式形式は使用しない
```

### パターンマッチング

| 設定 | 推奨 | 説明 |
|------|------|------|
| `csharp_style_pattern_matching_over_as_with_null_check` | ✅ | `as` と null チェックの代わりにパターンマッチングを使用 |
| `csharp_style_pattern_matching_over_is_with_cast_check` | ✅ | `is` とキャストの代わりにパターンマッチングを使用 |
| `csharp_style_prefer_pattern_matching` | ✅ | パターンマッチングを優先 |
| `csharp_style_prefer_not_pattern` | ✅ | `not` パターンを使用 |
| `csharp_style_prefer_switch_expression` | ✅ | switch 式を優先 |
| `csharp_style_prefer_extended_property_pattern` | ✅ | 拡張プロパティパターンを優先 |

```csharp
// ✅ 推奨
if (obj is string text)
{
    Console.WriteLine(text);
}

if (obj is not null)
{
    // 処理
}

var result = status switch
{
    Status.Active => "アクティブ",
    Status.Inactive => "非アクティブ",
    _ => "不明"
};

// ❌ 非推奨
var text = obj as string;
if (text != null)
{
    Console.WriteLine(text);
}

if (!(obj is null))
{
    // 処理
}
```

### null チェック

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_style_conditional_delegate_call` | true | デリゲートの条件付き呼び出し (`?.Invoke()`) を使用 |

```csharp
// ✅ 推奨
PropertyChanged?.Invoke(this, args);

// ❌ 非推奨
if (PropertyChanged != null)
{
    PropertyChanged(this, args);
}
```

### 修飾子設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_prefer_static_anonymous_function` | true | 静的な匿名関数を優先 |
| `csharp_prefer_static_local_function` | true | 静的なローカル関数を優先 |
| `csharp_style_prefer_readonly_struct` | true | readonly 構造体を優先 |
| `csharp_style_prefer_readonly_struct_member` | true | readonly 構造体メンバーを優先 |

**修飾子の順序:**

```
public, private, protected, internal, file, static, extern, new, virtual, abstract, sealed, override, readonly, unsafe, required, volatile, async
```

### コードブロックの設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_prefer_braces` | true | 常に波かっこを使用 |
| `csharp_prefer_simple_using_statement` | true | シンプルな using ステートメントを使用 |
| `csharp_style_namespace_declarations` | file_scoped | ファイルスコープの名前空間を使用 |
| `csharp_style_prefer_primary_constructors` | true | プライマリコンストラクターを優先 |
| `csharp_style_prefer_top_level_statements` | true | トップレベルステートメントを優先 |
| `csharp_style_prefer_method_group_conversion` | true | メソッドグループ変換を優先 |

```csharp
// ✅ 推奨: ファイルスコープの名前空間
namespace MyNamespace;

public class MyClass
{
    // ...
}

// ✅ 推奨: シンプルな using ステートメント
using var stream = new FileStream(path, FileMode.Open);

// ✅ 推奨: 常に波かっこを使用
if (condition)
{
    DoSomething();
}

// ✅ 推奨: プライマリコンストラクター
public class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
}

// ❌ 非推奨: ブロックスコープの名前空間
namespace MyNamespace
{
    public class MyClass
    {
        // ...
    }
}

// ❌ 非推奨: 波かっこなし
if (condition)
    DoSomething();
```

### 式レベルの設定

| 設定 | 推奨 | 説明 |
|------|------|------|
| `csharp_prefer_simple_default_expression` | ✅ | `default` を `default(T)` より優先 |
| `csharp_style_deconstructed_variable_declaration` | ✅ | 分解変数宣言を使用 |
| `csharp_style_implicit_object_creation_when_type_is_apparent` | ✅ | 型が明確な場合は暗黙的オブジェクト作成 (`new()`) を使用 |
| `csharp_style_inlined_variable_declaration` | ✅ | インライン変数宣言を使用 |
| `csharp_style_prefer_index_operator` | ✅ | インデックス演算子 (`^`) を使用 |
| `csharp_style_prefer_range_operator` | ✅ | 範囲演算子 (`..`) を使用 |
| `csharp_style_prefer_tuple_swap` | ✅ | タプルスワップを使用 |
| `csharp_style_prefer_utf8_string_literals` | ✅ | UTF-8 文字列リテラルを優先 |
| `csharp_style_throw_expression` | ✅ | throw 式を使用 |

```csharp
// ✅ 推奨
Person person = new();                              // 暗黙的オブジェクト作成
int value = default;                                // シンプルな default
var last = array[^1];                               // インデックス演算子
var slice = array[1..^1];                           // 範囲演算子
(a, b) = (b, a);                                    // タプルスワップ

if (int.TryParse(text, out int result))            // インライン変数宣言
{
    // 使用
}

// ❌ 非推奨
Person person = new Person();
int value = default(int);
var last = array[array.Length - 1];
```

### using ディレクティブの配置

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_using_directive_placement` | outside_namespace | using ディレクティブは名前空間の外に配置 |

```csharp
// ✅ 推奨
using System;
using System.Collections.Generic;

namespace MyNamespace;

public class MyClass { }

// ❌ 非推奨
namespace MyNamespace
{
    using System;
    using System.Collections.Generic;

    public class MyClass { }
}
```

---

## C# 書式ルール

### 改行設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_new_line_before_open_brace` | all | すべての場所で波かっこの前に改行 |
| `csharp_new_line_before_else` | true | `else` の前に改行 |
| `csharp_new_line_before_catch` | true | `catch` の前に改行 |
| `csharp_new_line_before_finally` | true | `finally` の前に改行 |
| `csharp_new_line_before_members_in_object_initializers` | true | オブジェクト初期化子のメンバー前に改行 |
| `csharp_new_line_before_members_in_anonymous_types` | true | 匿名型のメンバー前に改行 |
| `csharp_new_line_between_query_expression_clauses` | true | クエリ式の節の間に改行 |

```csharp
// ✅ 推奨: Allman スタイル
public void Method()
{
    if (condition)
    {
        // 処理
    }
    else
    {
        // 処理
    }
}

try
{
    // 処理
}
catch (Exception ex)
{
    // エラー処理
}
finally
{
    // クリーンアップ
}
```

### インデント設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_indent_block_contents` | true | ブロック内容をインデント |
| `csharp_indent_braces` | false | 波かっこ自体はインデントしない |
| `csharp_indent_case_contents` | true | case 内容をインデント |
| `csharp_indent_case_contents_when_block` | true | case がブロックの場合も内容をインデント |
| `csharp_indent_switch_labels` | true | switch ラベルをインデント |
| `csharp_indent_labels` | one_less_than_current | ラベルは現在より1つ少なくインデント |

```csharp
// ✅ 推奨
switch (value)
{
    case 1:
        DoSomething();
        break;
    case 2:
        {
            DoSomethingElse();
            break;
        }
    default:
        break;
}
```

### スペース設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_space_after_cast` | false | キャスト後にスペースなし |
| `csharp_space_after_keywords_in_control_flow_statements` | true | 制御フローキーワード後にスペース |
| `csharp_space_after_colon_in_inheritance_clause` | true | 継承句のコロン後にスペース |
| `csharp_space_before_colon_in_inheritance_clause` | true | 継承句のコロン前にスペース |
| `csharp_space_around_binary_operators` | before_and_after | 二項演算子の前後にスペース |
| `csharp_space_after_comma` | true | カンマ後にスペース |
| `csharp_space_before_comma` | false | カンマ前にスペースなし |
| `csharp_space_after_dot` | false | ドット後にスペースなし |
| `csharp_space_before_dot` | false | ドット前にスペースなし |
| `csharp_space_after_semicolon_in_for_statement` | true | for 文のセミコロン後にスペース |
| `csharp_space_before_semicolon_in_for_statement` | false | for 文のセミコロン前にスペースなし |
| `csharp_space_between_method_call_name_and_opening_parenthesis` | false | メソッド呼び出し名と開きかっこの間にスペースなし |
| `csharp_space_between_method_declaration_name_and_open_parenthesis` | false | メソッド宣言名と開きかっこの間にスペースなし |
| `csharp_space_between_parentheses` | false | かっこ内にスペースなし |

```csharp
// ✅ 推奨
int value = (int)obj;                              // キャスト後スペースなし
if (condition)                                      // キーワード後スペース
for (int i = 0; i < 10; i++)                       // セミコロン後スペース
int result = a + b;                                 // 二項演算子の前後にスペース
Method(arg1, arg2);                                 // カンマ後スペース
public class MyClass : BaseClass                    // コロンの前後にスペース

// ❌ 非推奨
int value = (int) obj;                             // キャスト後に不要なスペース
if(condition)                                       // キーワード後スペースなし
Method( arg1, arg2 );                              // かっこ内に不要なスペース
```

### 折り返し設定

| 設定 | 値 | 説明 |
|------|-----|------|
| `csharp_preserve_single_line_blocks` | true | 単一行ブロックを維持 |
| `csharp_preserve_single_line_statements` | true | 単一行ステートメントを維持 |

---

## 命名規則

### 重要度

命名規約の違反は**ビルドエラー**として扱われます (`IDE1006.severity = error`)。

### インターフェース

| ルール | 説明 |
|--------|------|
| プレフィックス | `I` で始まる |
| 大文字/小文字 | PascalCase |
| 重要度 | **エラー** |

```csharp
// ✅ 推奨
public interface IRepository { }
public interface IUserService { }

// ❌ 非推奨 (ビルドエラー)
public interface Repository { }      // I プレフィックスがない
public interface iRepository { }     // 小文字で始まっている
```

### 型 (クラス、構造体、列挙型)

| ルール | 説明 |
|--------|------|
| 大文字/小文字 | PascalCase |
| 重要度 | **エラー** |

```csharp
// ✅ 推奨
public class UserService { }
public struct Point { }
public enum Status { }

// ❌ 非推奨 (ビルドエラー)
public class userService { }         // 小文字で始まっている
public class user_service { }        // アンダースコア使用
```

### 非フィールドメンバー (プロパティ、イベント、メソッド)

| ルール | 説明 |
|--------|------|
| 大文字/小文字 | PascalCase |
| 重要度 | **エラー** |

```csharp
// ✅ 推奨
public string Name { get; set; }
public event EventHandler Changed;
public void ProcessData() { }

// ❌ 非推奨 (ビルドエラー)
public string name { get; set; }     // 小文字で始まっている
public void processData() { }        // 小文字で始まっている
```

### プライベート/内部フィールド

| ルール | 説明 |
|--------|------|
| プレフィックス | `_` (アンダースコア) で始まる |
| 大文字/小文字 | camelCase |
| 重要度 | **エラー** |

```csharp
// ✅ 推奨
private int _count;
private readonly string _name;
internal List<string> _items;
private string _firstName;

// ❌ 非推奨 (ビルドエラー)
private int count;                   // アンダースコアプレフィックスがない
private int Count;                   // PascalCase は不可
private int m_count;                 // m_ プレフィックスは不可
private int _Count;                  // camelCase でない
```

### 命名規則のまとめ

| 対象 | 命名スタイル | 例 |
|------|-------------|-----|
| インターフェース | I + PascalCase | `IRepository`, `IUserService` |
| クラス | PascalCase | `UserService`, `DataManager` |
| 構造体 | PascalCase | `Point`, `Rectangle` |
| 列挙型 | PascalCase | `Status`, `ErrorCode` |
| プロパティ | PascalCase | `Name`, `Count` |
| メソッド | PascalCase | `GetData()`, `ProcessItems()` |
| イベント | PascalCase | `Changed`, `PropertyChanged` |
| プライベートフィールド | _ + camelCase | `_count`, `_userName` |
| 内部フィールド | _ + camelCase | `_internalData` |
| ローカル変数 | camelCase | `count`, `userName` |
| パラメータ | camelCase | `userId`, `itemCount` |
| 定数 | PascalCase | `MaxCount`, `DefaultTimeout` |

---

## 付録: 設定の完全なリファレンス

この規約は `.editorconfig` ファイルに基づいており、Visual Studio や VS Code などの対応エディタで自動的に適用されます。

### エディタでの設定方法

1. プロジェクトのルートディレクトリに `.editorconfig` ファイルを配置
2. エディタがファイルを自動的に検出して設定を適用
3. 命名規則違反は IDE1006 として報告される

### 関連ドキュメント

- [EditorConfig 公式ドキュメント](https://editorconfig.org/)
- [.NET コーディング規則](https://docs.microsoft.com/dotnet/fundamentals/code-analysis/code-style-rule-options)
- [C# コーディング規則](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
