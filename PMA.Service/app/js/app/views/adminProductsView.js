(function (window, $, _, views) {
    "use strict";

    views.AdminProductsView = views.BaseView.extend({
        templateName: "adminProductsTemplate",
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