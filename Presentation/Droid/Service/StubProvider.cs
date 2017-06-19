using Android.Content;
using Android.Database;
using Android.Net;

namespace MeusPedidos.Catalogo.Presentation.Droid.Service
{
    [ContentProvider(new[] { "meuspedidos.catalogo.droid.service.provider" }, Exported = true, Syncable = true, Label = "StubProviderMeusPedidos", Enabled = true)]
    public class StubProvider : ContentProvider
    {
        public override int Delete(Uri uri, string selection, string[] selectionArgs)
        {
            return 0;
        }

        public override string GetType(Uri uri)
        {
            return string.Empty;
        }

        public override Uri Insert(Uri uri, ContentValues values)
        {
            return null;
        }

        public override bool OnCreate()
        {
            return true;
        }

        public override ICursor Query(Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            return null;
        }

        public override int Update(Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            return 0;
        }
    }
}