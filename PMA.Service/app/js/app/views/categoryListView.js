(function (window, $, _, views) {
    "use strict";

    views.UsersView = views.BaseView.extend({
        templateName: "categoriesTemplate",
        container: "#content",
        initialize: function (model) {
            this.model = model;
            this.listenTo(this.model, "all", this.render);
        },
        render: function () {
            this.$el.html(_.template(this.getTemplate()));
            $(this.container).html(this.$el);

            return this;
        }
    });
})(window, window.$, window._, window.App.views);