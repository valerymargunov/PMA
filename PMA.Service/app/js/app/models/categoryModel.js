(function (app, Backbone) {
    "use strict";

    app.models.categoryModel = Backbone.Model.extend({
        //defaults: {
        //    "title": '',
        //    "body": ''           
        //},
        urlRoot: app.config.serviceUrl + "category",
        //active: function (value) {
        //    this.set("active", value);
        //},
        //isFetched: function () {
        //    return this.get("body") && this.get("body").length > 0;
        //}
    });
})(window.App, window.Backbone);
