(function (window, $, _, views) {
    "use strict";

    views.AdminView = views.BaseView.extend({
        templateName: "adminTemplate",
        container: "#sidebar",
        initialize: function () {
        },
        render: function () {
            this.$el.html(_.template(this.getTemplate()));
            $(this.container).html(this.$el);

            return this;
        }
    });
})(window, window.$, window._, window.App.views);