﻿//Configuracin colores para el Menu Top
var colorFondo = ['#ccc', '#51B6DB', '#68B93D', '#DBBB51', '#B93D68', '#AFEEEE', '#D8BFD8'];
$('document').ready(function () {
    var menuActivo = $('#MenuActivo').val();
    //cambio a activo el li correspondiente
    $('#' + menuActivo).addClass('activo' + menuActivo);
    //cambio color de fondo de Menu Top
    $('.navbar-inverse').css('background-color', colorFondo[menuActivo]);
    $('.navbar-inverse').css('box-shadow','-5px 2px 5px ' + colorFondo[menuActivo]);
});
