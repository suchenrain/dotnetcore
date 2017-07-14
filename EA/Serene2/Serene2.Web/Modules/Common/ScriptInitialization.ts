/// <reference path="../Common/Helpers/LanguageList.ts" />

namespace Serene2.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('Serene2');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}