let links = document.querySelectorAll('.books');
let curId='all-books';
links.forEach((elem) => {
    let elemBooks = document.getElementById(`${elem.id}-books`);
    elem.addEventListener('click', () => {
        let booksContent = document.querySelectorAll('.books-content');
        booksContent.forEach((e)=>{
            e.classList.add('d-none');
        });
        elemBooks.classList.remove('d-none');
    });   
    return false;
});