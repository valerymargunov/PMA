(function (app, Backbone) {
    "use strict";

    app.models.CategoryList = Backbone.Collection.extend({
        model: app.models.CategoryModel,
        url: app.config.serviceUrl + "category"
    });
})(window.App, window.Backbone);
