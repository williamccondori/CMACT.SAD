var Knockout = Knockout || {};

Knockout.EliminarDetalle = function (lista, obj) {
    if (confirm(MensajeConfirmacion.Eliminar)) {
        if (obj.EstadoObjeto() == EstadoObjeto.Nuevo) {
            lista.remove(obj);
        } else {
            obj.Eliminado(true);
            obj.EstadoObjeto(EstadoObjeto.Modificado);
        }
    }
}

Knockout.BuscarObjeto = function (arrayBusqueda, nombrePropiedad, valor) {

    if (ko.isObservable(valor)) {
        valor = valor();
    }

    var objeto = ko.utils.arrayFirst(arrayBusqueda(), function (objeto) {
        var valorObtenido = Knockout.ObtenerValor(objeto, nombrePropiedad);
        return valorObtenido == valor;
    });

    return objeto;
}

Knockout.ConvertirJson = function (aoObjeto) {
    return JSON.stringify(ko.mapping.toJS(aoObjeto), function (key, value) {
        if (key != 'parent') {
            return value;
        };
    });
}

Knockout.LimpiarMensajes = function (ViewModel) {
    ViewModel.MensajeAlCliente("default");
    ViewModel.MensajeError("default");
    ViewModel.MensajeAdvertencia("default");
}

Knockout.ObtenerValor = function (aoObjeto, asUbicacionObjeto) {
    var keys = asUbicacionObjeto.split('.'), key, trace = aoObjeto;
    while (key = keys.shift()) {
        if (!trace[key]) {
            return null
        };
        trace = trace[key];
    }

    if (ko.isObservable(trace)) {
        trace = trace();
    }

    return trace;
}


var configuracionValidacion = {
    errorElementClass: 'sad-error',
    messagesOnModified: false,
    decorateInputElement: true,
    insertMessages: false
}

ko.validation.init(configuracionValidacion);


