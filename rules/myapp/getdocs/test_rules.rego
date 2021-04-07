package test

test_allow_large {
    data.myapp.getdocs.allow
    with input.label as "large"
}

test_not_allow_small {
    not data.myapp.getdocs.allow
    with input.label as "small"
}
test_fails {
    true
}