﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using Chinook.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }


        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            //This Message user control for error handling in place of using "Try Catch"
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                int id = int.Parse(ArtistDDL.SelectedValue);
                SearchArgID.Text = id.ToString();
                TracksBy.Text = "Artist";
                TracksSelectionList.DataBind(); //This statement causes the ODS to execute
            }, "Track Search", "Please select from the following list to add to your playlist.");

        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                int id = int.Parse(MediaTypeDDL.SelectedValue);
                SearchArgID.Text = id.ToString();
                TracksBy.Text = "MediaType";
                TracksSelectionList.DataBind(); //This statement causes the ODS to execute
            }, "Media Type Search", "Please select from the following list to add to your playlist.");
        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                int id = int.Parse(GenreDDL.SelectedValue);
                SearchArgID.Text = id.ToString();
                TracksBy.Text = "Genre";
                TracksSelectionList.DataBind(); //This statement causes the ODS to execute
            }, "Genre Search", "Please select from the following list to add to your playlist.");
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                //code to go here
                int id = int.Parse(AlbumDDL.SelectedValue);
                SearchArgID.Text = id.ToString();
                TracksBy.Text = "Album";
                TracksSelectionList.DataBind(); //This statement causes the ODS to execute
            }, "Album Search", "Please select from the following list to add to your playlist.");
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            //code to go here
           
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //code to go here
           if(string.IsNullOrEmpty(PlaylistName.Text))
           {
                /* Use the MessageUserControl method .ShowInfo("Title","message")*/
                MessageUserControl.ShowInfo("Required data", "Playlist Name is required to add a track");
           }
           else
           {
                //Collect the needed data
                string playlistname = PlaylistName.Text;

                //string username = User.Identity.Name;  --Comes from security
                string username = "HansenB";

                //Obtain the trackID from the ListView
                //CommandArgument is an object
                int trackid = int.Parse(e.CommandArgument.ToString());
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(playlistname, username, trackid);

                    List<UserPlaylistTrack> results = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = results;
                    PlayList.DataBind();
                },"Adding a Track","Track has been added to the playlist.");
           }
        }

    }
}