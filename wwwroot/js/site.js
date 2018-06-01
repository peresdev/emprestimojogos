$(function(){
    var burger = document.querySelector('.burger');
    var menu = document.querySelector('#'+burger.dataset.target);
    burger.addEventListener('click', function() {
        burger.classList.toggle('is-active');
        menu.classList.toggle('is-active');
    });
    $(".remover-amigo").click(function(){
        if (confirm('Deseja remover o amigo?')) {
            return true;
        } else {
            return false;
        }
    });

    $(".remover-jogo").click(function(){
        if (confirm('Deseja remover o jogo?')) {
            return true;
        } else {
            return false;
        }
    });
});