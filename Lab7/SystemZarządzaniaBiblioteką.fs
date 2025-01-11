module SystemZarządzaniaBiblioteką

open System

type Book(title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    member this.GetInfo() =
        sprintf "Tytuł: %s, \nAutor: %s, \nIlość stron: %d" this.Title this.Author this.Pages

type User(name: string) =
    let mutable borrowedBooks = []
    member this.Name = name
    member this.BorrowedBooks = borrowedBooks
    member this.BorrowBook(book: Book) =
        borrowedBooks <- book :: borrowedBooks
        printfn "%s wypożyczył: %s" this.Name book.Title
    member this.ReturnBook(book: Book) =
        borrowedBooks <- borrowedBooks |> List.filter ((<>) book)
        printfn "%s zwrócił: %s" this.Name book.Title

type Library() =
    let mutable books = []
    member this.AddBook(book: Book) =
        books <- book :: books
        printfn "Added: %s" book.Title
    member this.RemoveBook(book: Book) =
        books <- books |> List.filter ((<>) book)
        printfn "Removed: %s" book.Title
    member this.ListBooks() =
        if List.isEmpty books then
            printfn "No books available."
        else
            books |> List.iter (fun book -> printfn "%s" (book.GetInfo()))


let mainLibrarySystem() =
    let library = Library()
    let user = User("John Doe")

    let book1 = Book("The Hobbit", "J.R.R. Tolkien", 310)
    let book2 = Book("1984", "George Orwell", 328)

    library.AddBook(book1)
    library.AddBook(book2)

    library.ListBooks()

    user.BorrowBook(book1)
    library.RemoveBook(book1)

    library.ListBooks()

    user.ReturnBook(book1)
    library.AddBook(book1)

    library.ListBooks()

mainLibrarySystem()
