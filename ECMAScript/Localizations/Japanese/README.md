日本にだけ関係ある定数・列挙。

## 導入

```shell
npm i fundamental-constants-japan -E
```

## 内容
### 電話番号

| Constant name                                                                      | Value                  |
|------------------------------------------------------------------------------------|------------------------|
| `JAPANESE_PHONE_NUMBER_VALID_PATTERN__NO_N_DASHES_ALLOWED`                         | `/^\d{10,11}$/u`       |
| `JAPANESE_PHONE_NUMBER_VALID_PATTERN_TRADITIONAL_CONVENTION__N_DASHES_ARE_ALLOWED` | `/^(?:\d-?){10,11}$/u` |
| `MAXIMAL_DIGITS_COUNT_IN_JAPANESE_PHONE_NUMBER`                                    | `11`                   |
| `MINIMAL_DIGITS_COUNT_IN_JAPANESE_PHONE_NUMBER`                                    | `10`                   |
