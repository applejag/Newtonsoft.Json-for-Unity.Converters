
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

## Single

3. first

3. second

## One

1. first

1. second

## Ordered

1. first

2. second
