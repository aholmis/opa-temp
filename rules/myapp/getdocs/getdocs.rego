package myapp.getdocs

default allow = false
default deny = false

allow {
    data.myapp.getdocs.has_label_large
}

# deny {
#     false
# }