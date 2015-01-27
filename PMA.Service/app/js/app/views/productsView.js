(function (window, $, _, views) {
    "use strict";

    views.ProductsView = views.BaseView.extend({
        templateName: "productsTemplate",
        container: "#content",
        initialize: function () {
        },
        render: function () {
            this.$el.html(_.template(this.getTemplate()));
            $(this.container).html(this.$el);

            return this;
        }
    });
})(window, window.$, window._, window.App.views);