# UniAllSceneTester

すべてのシーンに対するテストを簡単に実装できるパッケージ

## 使用例

### すべてのシーンに対するテスト

```cs
using Kogane;
using NUnit.Framework;

public class Example
{
    [Test]
    public void すべてのシーンの名前が_10_文字以下か()
    {
        AllSceneTester.Test( scene => scene.name.Length <= 10 );
    }
}
```

### 特定のシーンに対するテスト

```cs
using Kogane;
using NUnit.Framework;

public class Example
{
    [Test]
    public void すべてのシーンの名前が_10_文字以下か()
    {
        AllSceneTester.Test
        (
            isValid: scene => scene.name.Length <= 11,

            // 「Assets/@Project」フォルダ以下のシーンを対象にテストする
            isTargetScene: scenePath => scenePath.StartsWith( "Assets/@Project" )
        );
    }
}
```
