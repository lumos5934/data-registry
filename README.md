# Data Registry

키 기반 빠른 조회와 조건 기반 유연한 검색을 제공하는 범용 데이터 관리 기능입니다. 다양한 데이터 타입을 하나의 구조로 등록하고 조회할 수 있도록 설계되었습니다.

<br>

[ Usage ](#usage) <br>
[ API ](#api)

<br>
<br>
<br>


## 🔧 Usage

데이터를 등록하고 Key 기반 조회 또는 Condition 기반 검색을 통해 데이터를 가져올 수 있습니다.  
기본적으로 Dictionary 기반의 빠른 접근과 List 기반의 조건 검색을 함께 제공합니다.

<br>

#### DataRegistry 생성

```cs
List<ItemData> items = LoadItems();

var registry = new DataRegistry<int, ItemData>(
    items,
    x => x.Id
);
```

<br> <br>

#### Key 기반 조회
```cs

var item = registry.Get(1001);

if (registry.TryGet(1001, out var data))
{
    // use data
}

```
<br> <br>

#### 조건 기반 조회
```cs
var result = registry.Find(new LevelCondition
{
    MinLevel = 10
});
```

```cs
var result = registry.Find(new AndCondition<ItemData>
{
    A = new LevelCondition { MinLevel = 10 },
    B = new TypeCondition { Type = ItemType.Weapon }
});

```

<br> <br>

#### 여러 결과 조회

```cs
var list = registry.FindAll(new TypeCondition
{
    Type = ItemType.Weapon
});
```

<br> <br> <br>

## 📖API
#### DataRegistry
**`Get(key)`** : Key 기반으로 데이터를 빠르게 조회합니다. <br>
**`TryGet(key, out value)`** : Key 존재 여부를 포함한 안전한 조회를 제공합니다. <br>
**`Find(condition)`** : 조건에 맞는 첫 번째 데이터를 반환합니다. <br>
**`FindAll(condition)`** : 조건에 맞는 모든 데이터를 반환합니다. <br>

<br>
<br>

#### ICondition
**`IsValid(T item)`** : 해당 데이터가 조건을 만족하는지 판단합니다. <br>


