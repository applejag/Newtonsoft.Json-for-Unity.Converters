# Codacy test

Testing the different configs of
<https://github.com/remarkjs/remark-lint/tree/master/packages/remark-lint-ordered-list-marker-value>

The `.remarkrc` contains the following

```json
{
    "plugins": [
        ["lint-ordered-list-marker-value", "ordered"]
    ]
}
```

So it should give errors on the #Single and #One sections

## Single line, single

3. first
3. second

## Single line, one

1. first
1. second

## Single line, ordered

1. first
2. second

## Multiline, single

3. first
   item

3. second
   item

## Multiline, one

1. first
   item

1. second
   item

## Multiline, ordered

1. first
   item

2. second
   item
