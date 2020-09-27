# UniAllSceneTester

すべてのシーンに対するテストを簡単に実装できるパッケージ

## 使用例

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
