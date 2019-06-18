﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiConfig : ScriptableObject
{
  public static string url = "https://sw2hs7ufb5gevarvuyswhrndjm.appsync-api.eu-west-1.amazonaws.com/graphql";
  public static string apiKey = "da2-gpogt2u3kzbgpo54oikxxgg7am";
  public static string generationsGraphQlQuery = "query getGenerations {listGenerations { items {id} }}";
  public static string generationsGraphQlMutation = "mutation createGeneration {createGeneration(input: {id: $id^, index: $index^}) { id, index }}";
  public static string newbornGraphQlMutation = "mutation NewbornPost {createNewborn(input: {id: '$id^', name: $name^, sex: $sex^, newbornGenerationId: '$newbornGenerationId^'}) {id, name, generation{index}}}";
  public static string postNewbornFromReproductionGraphQlMutation = "mutation NewbornPost {createNewborn(input: {id: '$id^', name: $name^, sex: $sex^, newbornGenerationId: '$newbornGenerationId^', parents:['$parentA^', '$parentB^']}) {id, name, generation{index}}}";
  public static string newbornsGraphQlQuery = "query NewbornsQuery {listNewborns(filter: {training: {eq: false}}, limit: 1000) {items {id, parents}}}";
  public static string modelGraphQlMutation = "mutation ModelPost {createModel(input: {id: '$id^', cellInfos: $cellInfos^, cellPositions: $cellPositions^, modelNewbornId: '$modelNewbornId^'}) { id, cellInfos }}";
  public static string newBornGraphQlQuery = "query getNewBorn {getNewborn(id: '$id^') { id, name, models { items { cellInfos } }, generation { id, index }  }}";
  public static string trainingGraphQlQuery = "query GetPost {start(newbornId: '$id^')}";
  public static string fetchModelGraphQlQuery = "query GetPost {fetchModel(newbornId: '$id^')}";
  public static string updateNewbornInstanceId = "mutation UpdateNewbornInstanceId {updateNewborn(input: {id: '$id^', instanceId: $instanceId^}) { id, instanceId }}";
  public static string updateTrainedStatus = "mutation UpdateTrainedStatus {updateNewborn(input: {id: '$id^', training: $status^}) { id }}";
  public static string updateNewbornChildsAndPartners = "mutation updateNewbornChilds {updateNewborn(input: {id: '$id^', childs: [$childs^], partners: [$partners^]}) { id }}";
  public static string updateTrainingStatusQuery = "mutation updateNewbornTrainingStatus {updateNewborn(input: {id: '$id^', trainingStage: '$stage^'}) { id }}";
  public static string updateLivingStatusQuery = "mutation updateNewbornTrainingStatus {updateNewborn(input: {id: '$id^', trainingStage: '$stage^'}) { id }}";
}